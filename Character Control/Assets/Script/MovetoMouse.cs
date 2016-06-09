using UnityEngine;
using System.Collections;

public class MovetoMouse : MonoBehaviour {
    public Transform target;
    public Vector2 MousePosition;
    public int maxDistance;
    // Use this for initialization
    void Start () {
        Debug.Log(target.position);
        maxDistance = 10;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = MousePosition;
	}
}
