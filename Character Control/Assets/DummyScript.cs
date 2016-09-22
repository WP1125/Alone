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
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (rb.velocity.magnitude * rb.gravityScale > killVelocity)
            {
                Destroy(gameObject);
            }
        }
    }
}
