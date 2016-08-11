using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody2D body;
	private double holdingTime=0.0;
	public float speed;
	public float jumpSpeed;
	public bool isGrounded;
	public double shiftTimer;
	public bool canSprint;
	public double dDown;
	public double sDown;
	public double aDown;
	public bool sClick;
	public bool dClick;
	public bool aClick;
	public bool sRelease;
	public bool dRelease;
	public bool aRelease;
    private bool facingRight;
	public class Timer{
		public Timer(double storeTime, double resetTime){
			
		}
	}
	void Update(){
		
	}
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		speed = 15f;
		jumpSpeed = 30f;
		isGrounded = false;
		shiftTimer = 5.0f;
        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");

        if (x != 0 && !GetComponent<Animator>().GetBool("Moving")) {
            GetComponent<Animator>().SetBool("Moving", true);
        }

        if (x == 0 && GetComponent<Animator>().GetBool("Moving")) {
            GetComponent<Animator>().SetBool("Moving", false);
        }

        if (x < 0 && facingRight) {
            facingRight = false;
            FlipSprite();
        }

        if (x > 0 && !facingRight) {
            facingRight = true;
            FlipSprite();
        }


		body.velocity = new Vector2 (x * speed, body.velocity.y);
		if (isGrounded) {
			jump ();
			sprint ();
			crawl ();

		}

		//print (body.velocity.x);
	}

	void jump(){
		/**
		if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)){
			holdingTime += Time.deltaTime;
			//print (holdingTime);
		}
		**/
		//print (holdingTime);
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space)) {
				body.velocity = new Vector2 (body.velocity.x, jumpSpeed);
			}
		}


	void sprint(){
		if (Input.GetKey (KeyCode.LeftShift) && shiftTimer > 1.0 && canSprint) {
			body.velocity = new Vector2 ((float)((double)(body.velocity.x) * 2), body.velocity.y);
            GetComponent<Animator>().SetBool("Sprinting", true);
			shiftTimer -= Time.deltaTime;
			if (shiftTimer <= 1.0) {
				canSprint = false;
			}
		} else if (shiftTimer <= 5.0) {
            if (GetComponent<Animator>().GetBool("Sprinting"))
            {
                GetComponent<Animator>().SetBool("Sprinting", false);
            }
			shiftTimer += Time.deltaTime;
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

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Ground" && !isGrounded) {
            isGrounded = true;
        }
    }
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
	void crawl(){
		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			sClick = true;
		} else {
			sClick = false;
		}
		if (Input.GetKey (KeyCode.S)) {
			sClick = true;
			sDown += Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			sClick = false;
			sRelease = true;
			sDown = 0;
		}
		if (Input.GetKey (KeyCode.D)) {
			dClick = true;
			dDown += Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			aClick = true;
			aDown += Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			dClick = false;
			dRelease = true;
			dDown = 0;
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			aClick = false;
			aRelease = true;
			aDown = 0;
		}
		if (sDown < 0.3 && dDown < 0.3){
			Debug.Log ("RollRight");
			dClick = false;
			sClick = false;
		}
		if (sDown < 0.3 && aDown < 0.3 && aClick && sClick) {
			Debug.Log ("RollLeft");
			aClick = false;
			sClick = false;
		}
		if (sDown > 0.3 && dDown > 0.3 && !dClick&&Input.GetKey(KeyCode.S)) {
			Debug.Log ("CrawlRight");
		}
		if (sDown > 0.3 && aDown > 0.3 && !aClick&&Input.GetKey(KeyCode.S)) {
			Debug.Log ("CrawlLeft");
		}
		if (sDown > 0.3 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
			Debug.Log ("duck");
		}
	}
		
			//Debug.Log (sDown);

    void FlipSprite() {
        Vector3 flipper = transform.localScale;
        flipper.x *= -1;
        transform.localScale = flipper;
    }


}

	

