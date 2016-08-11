using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RopeController : RaycastController {
    private GameObject player;
    public GameObject playerHook;
    public Vector3 velocity;
    public Vector3 oldPosition;
    public bool ropeInRange;
    float oldGravity;

    private Player playerScript;
    private BoxCollider2D playerCollider;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        oldPosition = transform.position;
        oldGravity = playerScript.gravity;
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        UpdateRaycastOrigins();
        Vector3 newPos = transform.position;
        velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        oldPosition = newPos;
 
        if (Input.GetKey(KeyCode.E) && ropeInRange)
        {   
            playerScript.gravity        = .0f;
            player.transform.position   = playerHook.transform.position;
            playerScript.enabled        = false;
            playerCollider.enabled      = false;
        }
        if (Input.GetKeyUp(KeyCode.E) || ropeInRange) 
        {
            playerScript.gravity    = oldGravity;
            playerScript.enabled    = true;
            playerCollider.enabled  = true;
            //player.GetComponent<Controller2D>().Move(velocity * Time.deltaTime, input);
        }

    }

}
