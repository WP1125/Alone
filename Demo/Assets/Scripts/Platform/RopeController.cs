using UnityEngine;
using System.Collections;

public class RopeController : RaycastController {
    public LayerMask passengerMask;


    // Use this for initialization
    public override void Start()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateRaycastOrigins();


    }
}
