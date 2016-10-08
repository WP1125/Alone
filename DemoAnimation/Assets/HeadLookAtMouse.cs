using UnityEngine;
using System.Collections;

public class HeadLookAtMouse : MonoBehaviour {
    private Rigidbody2D body;
    private GameObject parentObj;
    private Transform parentTransform;
    private Vector3 mousePos;
    private float newMx, newMy;
    private float topAngleMax;
    private float botAngleMax;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        parentObj = this.transform.parent.gameObject;
        parentTransform = this.transform.parent.gameObject.transform;
        animator = parentObj.GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        topAngleMax = 45;
        botAngleMax = -30;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void FixedUpdate()
    {
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
            animator.SetBool("facingRight", true);
        }
        else
        {
            angle = 180-angle;            
            if (angle >= topAngleMax && angle <= 180)
            {
                angle = topAngleMax;
            }
            else if (angle <= 360+botAngleMax && angle >=180)
            { 
                angle = 360+botAngleMax;
            }
            animator.SetBool("facingRight", false);
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

}
