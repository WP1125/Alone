using UnityEngine;
using System.Collections;

public class BoxSpawner : MonoBehaviour {


    public GameObject Box;
    public float maxWait = 5;
    public float minWait = 1;
    private float currWait = 0;
    private float spawnBox = 0;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        currWait+= Time.deltaTime;
        if(currWait > spawnBox)
        {
            currWait = 0;
            spawnBox = Random.Range(minWait, maxWait);
            Instantiate(Box, transform.position, Quaternion.identity);
        }
	}
}
