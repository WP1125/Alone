using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
    private Rigidbody2D body;
    private Transform parentTransform;
    private Vector3 mousePos;
    private float newMx, newMy;
    private float topAngleMax;
    private float botAngleMax;
    // Use this for initialization
    void Start () {
        parentTransform = this.transform.parent.gameObject.transform;
        topAngleMax = 75;
        botAngleMax = -60;
    }
	
	// Update is called once per frame
	void Update () {
		body = GetComponent<Rigidbody2D>();
	
	}
	void FixedUpdate(){
		lookAtMouse();
	}
    void lookAtMouse()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //mousePos.z = 10;
        newMx = mousePos.x - transform.position.x;
        newMy = mousePos.y - transform.position.y;
        float angle = Mathf.Atan2(newMy, newMx) * Mathf.Rad2Deg;
        if (mousePos.x > parentTransform.position.x)
        {
            if (angle >= topAngleMax)
            {
                angle = topAngleMax;
            }
            else if (angle <= botAngleMax)
            {
                angle = botAngleMax;
            }
        }
        else
        {
            angle = 180 - angle;
            if (angle >= topAngleMax && angle <= 180)
            {
                angle = topAngleMax;
            }
            else if (angle <= 360+botAngleMax && angle >= 180)
            {
                angle =360+botAngleMax;
            }
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
