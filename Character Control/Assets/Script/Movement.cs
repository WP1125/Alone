using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody2D body;
	public float speed; //maxspeed
	public float jumpSpeed; //speed for jump
	public bool isGrounded; //if character is on ground
	public double shiftTimer;
	public bool canSprint; //if the character can sprint
    public float currentSpeed; //currentspeed
    public float timestamp; 
    public int rollCooldown;
	public double dDown;
	public double sDown;
	public double aDown;
	public int rollNumber; //how many rolls the character have left
	public double timer;
	public bool sprinting;
	public bool downing;
	public bool jumping;
	void Update(){
		timer += Time.deltaTime;
		if (timer > 5.0&&rollNumber<5) {
			rollNumber += 1;
			timer = 0.0;
		}
	}
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		speed = 15f;
		jumpSpeed = 30f;
		isGrounded = false;
		shiftTimer = 5.0;
		rollNumber = 5;
		sprinting = false;
        rollCooldown = 2;
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
   void roll() {
        if (currentSpeed > 10 && Input.GetKey(KeyCode.S) && rollNumber>=1 && timestamp<=Time.time) {
            timestamp = Time.time + rollCooldown;
            Debug.Log("roll");
            rollNumber -= 1;

        }
    }
	/**void crawl(){
		if (Input.GetKey (KeyCode.S)) {
			if (Input.GetKey (KeyCode.D)) {
				dDown += Time.deltaTime;
			} else if(Input.GetKey(KeyCode.A)){
				aDown+=Time.deltaTime;
			} else {
				//downing = true;
				body.velocity = new Vector2 (0, 0);
			}
			if (dDown > 0.3) {
				//downing = true;
				body.velocity = new Vector2 (3, body.velocity.y);
			}
			if (aDown > 0.3) {
				//downing = true;
				body.velocity = new Vector2 (-3, body.velocity.y);
			}
			if (Input.GetKeyUp (KeyCode.D)) {
				if (dDown < 0.3&&rollNumber>1) {
					//downing = true;
					body.position = new Vector3 (body.position.x + 3, body.position.y, 0);
					rollNumber -= 1;
				}
				dDown = 0;
			}
			if (Input.GetKeyUp (KeyCode.A)) {
				if (aDown < 0.3&&rollNumber>1) {
					//downing = true;
					body.position = new Vector3 (body.position.x - 3, body.position.y, 0);
					rollNumber -= 1;
				}
				aDown=0;
			}
		}
    **/
    
		/**
		if (Input.GetKey (KeyCode.S)) {
			sClick = true;
			sDown += Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			dRelease = false;
			dClick = true;
			dDown += Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			dClick = false;
			dRelease = true;
			dDown = 0;
		}
		if (Input.GetKey (KeyCode.S) && dClick && dDown > 0.3) {
			Debug.Log ("Crawl Right");
		}
		else if(Input.GetKey(KeyCode.S)&&dRelease){
			Debug.Log("Roll Right");
		}
		else if(Input.GetKey(KeyCode.S)){
			Debug.Log("duck");
		}
	}
	**/
		
			//Debug.Log (sDown);
}

	

