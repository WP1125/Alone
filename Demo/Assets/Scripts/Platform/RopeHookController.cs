using UnityEngine;
using System.Collections;

public class RopeHookController : MonoBehaviour {

    public RopeController ropeController;
     
	// Use this for initialization
	void Start () {
        ropeController.ropeInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            print("entered");
            ropeController.ropeInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            print("Exit");
            ropeController.ropeInRange = false;
        }
    }
}
