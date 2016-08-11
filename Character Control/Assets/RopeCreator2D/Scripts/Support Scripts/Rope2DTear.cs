using UnityEngine;

//if you attach it to the created rope's folder, the rope will be able to tear

public class Rope2DTear : MonoBehaviour {

    [Range(0.2f, 1.5f)]
    public float ropeStretchValue = 1.1f;

    private GameObject[] ropeBits;
    private float distance;

    private int childCount;

    void Start()
    {
        childCount = transform.childCount;

        ropeBits = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            ropeBits[i] = transform.GetChild(i).gameObject;
        }
    }

	void Update () 
    {
        if(childCount != transform.childCount)
        {
            ropeBits = new GameObject[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                ropeBits[i] = transform.GetChild(i).gameObject;
            }
            childCount = transform.childCount;
            //Debug.Log("counting");
        }

        //if the distance between the ropeBits gets more than the CircleCollider2D's diagonal + ropeStrength, then the rope will tear
        for(int i = 0; i < transform.childCount; i++)
        {
            if (ropeBits[i] != ropeBits[0] && ropeBits[i] != null)
            {
                distance = Vector3.Distance(ropeBits[i].transform.position, ropeBits[i - 1].transform.position);

                if (ropeBits[i].GetComponent<CircleCollider2D>() != null)
                {
                    if (distance > ropeBits[i].GetComponent<CircleCollider2D>().radius * (2.0f + ropeStretchValue) * ropeBits[i].transform.localScale.x)
                    {
                        if (ropeBits[i].GetComponent<HingeJoint2D>() != null)
                        {
                            ropeBits[i].GetComponent<HingeJoint2D>().enabled = false;
                        }
                        if (ropeBits[i].GetComponent<DistanceJoint2D>() != null)
                        {
                            ropeBits[i].GetComponent<DistanceJoint2D>().enabled = false;
                        }
                    }
                }
            }
        }
	}
}
