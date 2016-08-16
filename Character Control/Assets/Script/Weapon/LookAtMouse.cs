using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
	public Vector3 mousePos;
    private bool facingRight;

	// Use this for initialization
	void Start () {
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		lookAtMouse ();
	}
	void lookAtMouse(){
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		mousePos.z = 10;
		mousePos.x = mousePos.x - transform.position.x;
		mousePos.y = mousePos.y - transform.position.y;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        


        if (mousePos.x < 0 && facingRight) {
            facingRight = false;
            FlipSprite();
        }

        if (mousePos.x > 0 && !facingRight) {
            facingRight = true;
            FlipSprite();
        }

        if (!transform.parent.GetComponent<Movement>().facingRight)
        {
            Quaternion neg;
            neg = transform.rotation;
            neg.z *= -1;
            transform.rotation = neg;
        }



	}


    void FlipSprite() {
        Vector3 flipper = transform.localScale;
        //flipper. *= -1;
        flipper.y *= -1;
        transform.localScale = flipper;
    }

}
