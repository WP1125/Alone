using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

    private Vector2 direction;
    public int visionRange;
    public int speed;
    public int shootRange;
    private Transform player;
    private Vector2[] directions = { Vector2.right, Vector2.left };
    private int index;
    private bool currDirectionRight;
    private float currTime;
    private Rigidbody2D rb;
    
	// Use this for initialization
	void Start () {
        direction = transform.TransformDirection(Vector2.right);
        currDirectionRight = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        index = Random.Range(0, 2);
    }
	
	// Update is called once per frame
	void Update () {
        currTime += Time.deltaTime;
	}

    void FixedUpdate()
    {
        float distancep = player.position.x - transform.position.x;
        if (Mathf.Abs(distancep) < shootRange)
        {
            GetComponent<Shooting>().playerInRange = true;
            //If enemy currently facing the wrong way when player comes in range flip the sprite
            if ((distancep > 0 && direction.x < 0) || (distancep < 0 && direction.x > 0))
            {
                FlipSprite();

            }
            if (currTime > .5)
            {
                currTime = 0;
                playerInRange(distancep);
            }
            

        }
        else
        {
            GetComponent<Shooting>().playerInRange = false;
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction);
            if (hit2D.collider != null)
            {
                float distance = Mathf.Abs(hit2D.point.x - transform.position.x);
                if (distance <= visionRange)
                {

                    FlipSprite();
                }

            }

            rb.velocity = direction * speed;
        }
        
    }


    void playerInRange(float distancep)
    {
        if (Mathf.Abs(distancep) < shootRange - 5)
        {
            if (currDirectionRight)
            {
                rb.velocity = -transform.right * speed;
            }
            else
            {
                rb.velocity = transform.right * speed;
            }
        }
        else if (Mathf.Abs(distancep) >= shootRange - 5)
        {
            if (currDirectionRight)
            {
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = -transform.right * speed;
            }
        }
    }


    void FlipSprite()
    {

        

        //flip whole object including children sprites
        Vector3 flipper = transform.localScale;
        flipper.x *= -1;
        transform.localScale = flipper;
        direction *= -1;
        currDirectionRight = !currDirectionRight;

    }
}
