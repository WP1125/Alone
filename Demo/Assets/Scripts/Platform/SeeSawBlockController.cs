using UnityEngine;
using System.Collections;

public class SeeSawBlockController : MonoBehaviour {

    public GameObject thisBlock;
    public GameObject otherBlock;

    //PlZ use 2 items;
    public Vector3[] limits;
    Vector3[] globalWaypoints;

    public int passengerCount;

    private Vector3 previousPosition;


	void Start () {
        previousPosition = transform.position;

        globalWaypoints = new Vector3[limits.Length];
        for (int i = 0; i < limits.Length; i++)
        {
            globalWaypoints[i] = limits[i] + transform.position;
        }
    }
	
	void Update () {
        if (transform.position.y < previousPosition.y) {
            Vector3 newPos = otherBlock.transform.position;
            newPos -= (transform.position - previousPosition);
            otherBlock.transform.position = newPos;
        }
        previousPosition = transform.position;

        SeeSawBlockController otherSeeSawController = otherBlock.transform.GetChild(0).gameObject.GetComponent<SeeSawBlockController>();
        if (passengerCount > otherSeeSawController.passengerCount
            && transform.position.y > globalWaypoints[1].y && otherBlock.transform.position.y < otherSeeSawController.globalWaypoints[0].y)
        {
            thisBlock.transform.Translate(new Vector2(0, -0.02f));
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        other.gameObject.transform.Translate(new Vector2(0, -0.02f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Movable")
        {
            passengerCount++;
        }
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Movable")
        {
            passengerCount--;
        }
            
    }

    void OnDrawGizmos()
    {
        if (limits != null)
        {
            Gizmos.color = Color.red;
            float size = .3f;

            for (int i = 0; i < limits.Length; i++)
            {
                Vector3 globalWaypointPos = (Application.isPlaying) ? globalWaypoints[i] : limits[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
            }
        }
    }
}
