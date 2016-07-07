using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SlectedItem : MonoBehaviour {

    private Text selectedItemText;
    private List<BaseItem> playerInventory;
    private BasePlayer basePlayerScript;

    // Use this for initialization
    void Start () {
        selectedItemText = GameObject.Find("Selected_item_text").GetComponent<Text>();
        basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Toggle>().isOn && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);

            basePlayerScript.playerHP += 20;
            //int itemIndex = System.Int32.Parse(this.gameObject.name);
            //playerInventory.Remove(playerInventory[itemIndex]);
            //print(playerInventory.Count);
        }

    }

    public void ShowSelectedItemText()
    {
        if (this.gameObject.GetComponent<Toggle>().isOn)
        {
            if (this.gameObject.name == "Empty"){
                selectedItemText.text = "This slot is empty.";
            }
            else
            {
                int itemIndex = System.Int32.Parse(this.gameObject.name);
                selectedItemText.text = playerInventory[itemIndex].ItemName + ", " + playerInventory[itemIndex].ItemDescription;
            }
        }
    }
}
