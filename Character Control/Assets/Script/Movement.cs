using UnityEngine;
using System.Collections;

public class Movement : Staminas {
    private Rigidbody2D body;
    public float maxSpeed;
    public float jumpForce;
    public float distToGround;
    public LayerMask groundLayerMask;
    bool doubleJump;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        maxSpeed = 15f;
        jumpForce = 30f;
        doubleJump = false;
    }

    void FixedUpdate()
    {
        //Debug.Log(landed);
        basicMovement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause");
        }
        if(Input.GetKeyDown(KeyCode.Tab)||Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Menu/Map");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Switch between hand/elemental");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("BackPack");
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(2))
        {
            Debug.Log("Melee");
        }
    }

    void basicMovement()
    {
        Vector2 vel = new Vector2(0, body.velocity.y);
        if (Input.GetKey(KeyCode.A)){
            vel = vel + new Vector2(-1 * maxSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel = vel + new Vector2(1 * maxSpeed, 0);
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
                {
                    vel = vel + new Vector2(0, jumpForce);
                }
            
            else if (!doubleJump)
            {
                doubleJump = true;
                vel = new Vector2(vel.x, jumpForce);
            }       
        }
        if (Input.GetKey(KeyCode.S) && isGrounded()) {
            //crouch
            vel = new Vector2((float)(vel.x / 2), vel.y);
        }
        body.velocity = vel;
    }
    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distToGround+0.1f, groundLayerMask);
        if (hit.collider != null) {
            return true;
        }
        else {return false; }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") { doubleJump = false; }
    }

}
/*
public class Movement : MonoBehaviour {

	private Rigidbody2D body;
	public float speed; //maxspeed
	public float jumpSpeed; //speed for jump
	public bool isGrounded; //if character is on ground
	public double shiftTimer;
	public bool canSprint; //if the character can sprint
    public float currentSpeed; //currentspeed
    public float timestamp;
    public bool sprinting;
	void Update(){

	}
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		speed = 15f;
		jumpSpeed = 30f;
		isGrounded = false;
		shiftTimer = 5.0;
		sprinting = false;
        timestamp = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxis ("Horizontal");
		body.velocity = new Vector2 (x * speed, body.velocity.y);
        currentSpeed = body.velocity.x;
		if (isGrounded) {
			jump ();
			sprint ();
			//crawl ();
            roll();
		}

	}

	void jump(){
		if (Input.GetKeyDown (KeyCode.W) && sprinting) {
			Debug.Log ("goign");
			jumping = true;
			body.velocity = new Vector2 (body.velocity.x, jumpSpeed);
			body.AddForce (new Vector2 (10000, 0));
		} else if (Input.GetKeyDown (KeyCode.W)) {
			jumping = true;
			body.velocity = new Vector2 (body.velocity.x, jumpSpeed);
		} else {
			jumping = false;
		}
	}


	void sprint(){
		if (Input.GetKey (KeyCode.LeftShift) && shiftTimer > 1.0 && canSprint) {
			body.velocity = new Vector2 ((float)((double)(body.velocity.x) * 2), body.velocity.y);
			shiftTimer -= Time.deltaTime;
			sprinting = true;
			if (shiftTimer <= 1.0) {
				canSprint = false;
			}
		} else if (shiftTimer <= 5.0) {
			shiftTimer += Time.deltaTime;
			sprinting = false;
		} else {
			sprinting = false;
		}

		if (shiftTimer >= 2.0) {
			canSprint = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

}

	
    */

