using UnityEngine;

public class Rope2DLineRendSetPoints : MonoBehaviour {


    LineRenderer lineRenderer;

	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
	

	void Update ()
    {
        lineRenderer.SetPosition(0, GetComponent<HingeJoint2D>().anchor * 1.15f);
        lineRenderer.SetPosition(1, (-1 * GetComponent<HingeJoint2D>().anchor) * 1.15f);
    }
}
