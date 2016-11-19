using UnityEngine;
using System.Collections;

public class GrabScript : MonoBehaviour {


    public ArrayList inRangeObjects = new ArrayList();
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PickUp" || other.tag == "Explosive")
        {
            inRangeObjects.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PickUp" || other.tag == "Explosive")
        {
            inRangeObjects.Remove(other.gameObject);
        }
    }
}
