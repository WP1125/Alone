﻿using UnityEngine;
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
        if (this.gameObject.GetComponent<Toggle>().isOn && Input.GetKeyDown(KeyCode.E))
        {
            int itemIndex = System.Int32.Parse(this.gameObject.name);
			if (playerInventory [itemIndex].ItemType == BaseItem.ItemTypes.POTION) {
				playerInventory [itemIndex].ItemName = "Empty";
				this.transform.GetChild (0).gameObject.SetActive (false);
				selectedItemText.text = "Item comsumed";

				basePlayerScript.playerHP += 20;
			} else {
				selectedItemText.text = "Item connot be comsumed";
			}
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

    public void OnDrag(PointerEventData eventData)
    {
        GameObject.Find("Inventory Window").GetComponent<InventoryWindow>().ShowDraggedItem();
    }
}
