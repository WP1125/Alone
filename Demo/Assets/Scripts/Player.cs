using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
    Controller2D controller;

    //general variables
    public float moveSpeed = 6;
    float gravity;
    Vector3 velocity;
    float velocityXSmoothing;

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


	void Start() {
		controller = GetComponent<Controller2D> ();

        //Caculating gravity
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);

        //variable jump height. Press longer will jump higher
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		print ("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
	}

	void Update() {
        //Get player input and wall direction
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		int wallDirX = (controller.collisions.left) ? -1 : 1;

        //Smoothen acceleration
		float targetVelocityX = input.x * moveSpeed;
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
				velocity.y = maxJumpVelocity;
		}

		if (Input.GetKeyUp (KeyCode.Space))
			if (velocity.y > minJumpVelocity) 
				velocity.y = minJumpVelocity;
	
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) 
			velocity.y = 0;

	}
}
