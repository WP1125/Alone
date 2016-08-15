using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {
    public GameObject[] keys;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public bool HasAllKeys()
    {
        foreach (GameObject key in keys)
        {
            if (key.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
