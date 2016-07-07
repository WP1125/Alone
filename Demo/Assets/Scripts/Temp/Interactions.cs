using UnityEngine;
using System.Collections;

public class Interactions : MonoBehaviour {
	public bool inventoryOpen;

	// Use this for initialization
	void Start () {
		inventoryOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.F)) {
			openInventory ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			switchWeapon ();
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			interact ();
		}
	}
	void openInventory(){ 
		if (inventoryOpen) {
			print ("Close Inventory");
			inventoryOpen = false;
		} else {
			print ("Open Inventory");
			inventoryOpen = true;
		}
	}
	void switchWeapon(){
		print("Switch Weapon");
	}
	void interact(){
		print ("Interact");
	}
}
