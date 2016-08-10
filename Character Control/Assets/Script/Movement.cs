using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
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
        if(gameObject.transform.position.y<-50)
        {
            GameControl.control.Load();
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
        if (col.gameObject.layer == 10) { GameControl.control.Save();  }
    }

}

