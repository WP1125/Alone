using UnityEngine;
using System.Collections;

public class MouseAim : AimingScript {
    public Transform target;
    public Transform targetObject;
    public float distance;
    public float angle;
    // Use this for initialization
    void Start () {
        MousePosition = getMousePosition();
        targetObject=(Transform) Instantiate(target, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
        MaxDistance = 10;
    }
	
	// Update is called once per frame
	void Update () {
        distance = getDistancePlus();
        angle = getAnglePlus();
        if (distance <= MaxDistance)
        {
            targetObject.position = new Vector3(MousePosition.x, MousePosition.y, 0);
        }
        else {
            targetObject.position = new Vector3(MaxDistance * Mathf.Cos(angle)+MainPlayer.transform.position.x, MaxDistance * Mathf.Sin(angle)+MainPlayer.transform.position.y, 0);
        }
    }


}
