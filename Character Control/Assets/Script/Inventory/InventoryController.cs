using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour {

    public GameObject inventory;
    private GameObject player;

	void Start () {
        inventory.SetActive(false);
	}
	
	void Update () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }

        player.GetComponent<Player>().enabled = !inventory.activeSelf;
    }
}
