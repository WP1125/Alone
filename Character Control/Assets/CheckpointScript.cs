using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {



    private bool hit = false;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && hit == false)
        {
            hit = true;
            Debug.Log("Checkpoint");
            GameObject gm = GameObject.FindGameObjectWithTag("GameMaster");
            gm.GetComponent<GameMaster>().CheckPointHit = true;
            gm.GetComponent<GameMaster>().checkPointPos = transform.position;

        }
    }
}
