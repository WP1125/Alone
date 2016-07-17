using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
	private Rigidbody2D body;
	public Vector3 mousePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		body = GetComponent<Rigidbody2D>();
	
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
	}
}
