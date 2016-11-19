using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SlectedItem : MonoBehaviour, IDragHandler {

    private Text selectedItemText;
    private List<BaseItem> playerInventory;
    private BasePlayer basePlayerScript;
    


    void Start () {
        selectedItemText = GameObject.Find("Selected_item_text").GetComponent<Text>();
        basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
    }

	void Update () {
        if (GetComponent<Toggle>().isOn && Input.GetKeyDown(KeyCode.E))
        {
            int itemIndex = System.Int32.Parse(gameObject.name);
			if (playerInventory [itemIndex].ItemType == BaseItem.ItemTypes.POTION) {
				playerInventory [itemIndex].ItemName = "Empty";
				transform.GetChild (0).gameObject.SetActive (false);
				selectedItemText.text = "Item comsumed";

                comsumePotion(playerInventory[itemIndex]);
			}
            if (playerInventory[itemIndex].ItemName == "Battery" && Player.inRangeSocket)
            {
                playerInventory[itemIndex].ItemName = "Empty";
                transform.GetChild(0).gameObject.SetActive(false);
                selectedItemText.text = "Used Battery";
                //Whatever battery does should go here.

                Player.useBattery = true;
            }

            else
            {
                selectedItemText.text = "Item connot be comsumed";
            }
        }
    }

    public void ShowSelectedItemText()
    {
        if (GetComponent<Toggle>().isOn)
        {
            if (gameObject.name == "Empty"){
                selectedItemText.text = "This slot is empty.";
            }
            else
            {
                int itemIndex = System.Int32.Parse(gameObject.name);
                selectedItemText.text = playerInventory[itemIndex].ItemName + ", " + playerInventory[itemIndex].ItemDescription;
            }
        }
    }

    public void comsumePotion(BaseItem item)
    {
        if (item.ItemType == BaseItem.ItemTypes.POTION)
        {
            basePlayerScript.increaseHP(20);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject.Find("Inventory Window").GetComponent<InventoryWindow>().ShowDraggedItem();
    }
}
