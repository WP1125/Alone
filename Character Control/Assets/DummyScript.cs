using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {

    // Use this for initialization

    public float killVelocity;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "PickUp" && other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > killVelocity)
        {
            Destroy(gameObject);
        }
    }
}
