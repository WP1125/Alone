using UnityEngine;
using System.Collections;

public class MouseAim : AimingScript {
    public GameObject target;
    //public Transform target;
    //GameObject targetObject;
    public float distance;
    public float angle;

    // Use this for initialization
    void Start () {
        MousePosition = getMousePosition();
        //targetObject=Instantiate(target);
        MaxDistance = 10;
    }
	
	// Update is called once per frame
	void Update () {
        distance = getDistancePlus();
        angle = getAnglePlus();
        if (distance <= MaxDistance)
        {
            target.transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
            //targetObject.transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
        }
        else {
            target.transform.position = new Vector3(MaxDistance * Mathf.Cos(angle) + MainPlayer.transform.position.x, MaxDistance * Mathf.Sin(angle) + MainPlayer.transform.position.y, 0);
            //targetObject.transform. position = new Vector3(MaxDistance * Mathf.Cos(angle)+MainPlayer.transform.position.x, MaxDistance * Mathf.Sin(angle)+MainPlayer.transform.position.y, 0);
        }
    }


}
