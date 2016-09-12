using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
    Controller2D controller;

    //general variables
    public float moveSpeed          = 6;
    public float crouchMultiplier   = .5f;
    public float gravity;
    public Vector3 velocity;
    float velocityXSmoothing;
    private bool holding = false;
    private ArrayList inRangeObjects = new ArrayList();
    private GameObject heldObject;
    private Vector3 prevScale;

    //variables for ground jumping
    public float maxJumpHeight      = 4;
	public float minJumpHeight      = 1;
	public float timeToJumpApex     = .4f;
	float accelerationTimeAirborne  = .2f;
	float accelerationTimeGrounded  = .1f;
    float maxJumpVelocity;
    float minJumpVelocity;

    //Variables for wall jumping
    public bool wallJump;
    public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public float wallSlideSpeedMax  = 3;
	public float wallStickTime      = .25f;
	float timeToWallUnstick;

    private bool doubleJump;

    public bool facingRight = true;


	void Start() {
		controller = GetComponent<Controller2D> ();
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
        doubleJump = false;

        //variable jump height. Press longer will jump higher
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
	}

	void Update() {
        //Get player input and wall direction
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		int wallDirX = (controller.collisions.left) ? -1 : 1;


        //Animation change depending on movement type

        Animator playerAnim = GetComponent<Animator>();
        if (playerAnim != null)
        {
            if (input.x != 0 && !playerAnim.GetBool("Moving"))
            {
                playerAnim.SetBool("Moving", true);
            }

            if (input.x == 0 && playerAnim.GetBool("Moving"))
            {
                playerAnim.SetBool("Moving", false);
            }

            if (input.x < 0 && facingRight)
            {
                facingRight = false;
                FlipSprite();
            }

            if (input.x > 0 && !facingRight)
            {
                facingRight = true;
                FlipSprite();
            }

            if (input.x != 0 && Input.GetKey(KeyCode.LeftShift) && !playerAnim.GetBool("Sprinting"))
            {
                playerAnim.SetBool("Sprinting", true);
            }

            if (playerAnim.GetBool("Sprinting") && !Input.GetKey(KeyCode.LeftShift))
            {
                playerAnim.SetBool("Sprinting", false);
            }


            if (Input.GetKeyDown(KeyCode.S) && playerAnim.GetBool("Crouching") == false)
            {
                playerAnim.SetBool("Crouching", true);
            }

            if (Input.GetKeyUp(KeyCode.S) && playerAnim.GetBool("Crouching") == true)
            {
                playerAnim.SetBool("Crouching", false);
            }

        }


        //Grab

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if (holding)
                {
                    holding = false;
                    Drop(heldObject);
                }
                else if(inRangeObjects.Count > 0 && !Input.GetMouseButtonDown(0))
                {
                    holding = true;
                    GameObject closest = inRangeObjects[0] as GameObject;
                    float shortestDist = Vector3.Distance(closest.transform.position, transform.position);
                    foreach(GameObject g in inRangeObjects)
                        {
                            float currDist = Vector3.Distance(g.transform.position, transform.position);
                            if (currDist < shortestDist)
                            {
                                closest = g;
                                shortestDist = currDist;
                            }
                        }
                    Grab(closest);
                }
            }





        float targetVelocityX = input.x * moveSpeed;

        //if (Input.GetKey(KeyCode.S) && input.x != 0)
        //{
        //    targetVelocityX = targetVelocityX * crouchMultiplier;
        //}
            
        //Smoothen acceleration
        velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

        //Handling wall jumping
		bool wallSliding = false;
		if (wallJump && (controller.collisions.left || controller.collisions.right) 
            && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;

			if (velocity.y < -wallSlideSpeedMax) 
				velocity.y = -wallSlideSpeedMax;

			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (input.x != wallDirX && input.x != 0) 
					timeToWallUnstick -= Time.deltaTime;
				else 
					timeToWallUnstick = wallStickTime;
			}
			else 
				timeToWallUnstick = wallStickTime;
		}

        //Handle Input for Jumping
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (wallJump && wallSliding) {
				if (wallDirX == input.x) {
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
				}
				else if (input.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
				}
				else {
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
				}
			}
            if (controller.collisions.below)
            {
                velocity.y = maxJumpVelocity;
                doubleJump = true;
            }

            //double jump
            else if (Input.GetKey(KeyCode.W) && doubleJump)
            {
                velocity.y = maxJumpVelocity;
                doubleJump = false;
            }

        }

        if (Input.GetKeyUp (KeyCode.Space))
			if (velocity.y > minJumpVelocity) 
				velocity.y = minJumpVelocity;
	
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) 
			velocity.y = 0;

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PickUp")
        {
            inRangeObjects.Add(other.gameObject);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PickUp")
        {
            inRangeObjects.Remove(other.gameObject);
        }
    }
    




    void FlipSprite()
    {

        //Flip children so that when enitre sprite is flipped children are flipped back to original position
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 childFlip = transform.GetChild(i).localScale;
            childFlip.x *= -1;
            //childFlip.z *= -1;
            transform.GetChild(i).localScale = childFlip;
        }

        //flip whole object including children sprites
        Vector3 flipper = transform.localScale;
        flipper.x *= -1;
        transform.localScale = flipper;

    }


    void Grab(GameObject other)
    {
        heldObject = other;
        prevScale = other.transform.localScale;
        other.transform.parent = transform;
        


        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        other.transform.localPosition = new Vector3(1.4f, 0f, 0f);

    }

    void Drop(GameObject other)
    {
        other.transform.parent = null;
        heldObject = null;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        inRangeObjects.Remove(other);
        other.transform.localScale = prevScale;
        rb.isKinematic = false;

    }
}
