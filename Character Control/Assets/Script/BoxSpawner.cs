using UnityEngine;
using System.Collections;

public class BoxSpawner : MonoBehaviour {


    public GameObject Box;
    public float maxWait = 5;
    public float minWait = 1;
    public int maxBoxCount = 5;
    private float currWait = 0;
    private float spawnBox = 0;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        currWait+= Time.deltaTime;
        if(currWait > spawnBox && transform.childCount < maxBoxCount)
        {
            currWait = 0;
            spawnBox = Random.Range(minWait, maxWait);
            GameObject SpawnedBox = Instantiate(Box, transform.position, Quaternion.identity) as GameObject;
            SpawnedBox.transform.parent = transform;
        }
	}
}
