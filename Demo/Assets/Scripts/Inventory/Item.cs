using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Item : MonoBehaviour {

    public GameObject player;
    public GameObject inventoryWindow;
    private BaseItem thisItem;
    private List<BaseItem> playerInventory;

    void Start () {
        thisItem = new BaseItem();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ReturnItemIcon(thisItem);
	}
	
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            bool inventory_full = true;
            playerInventory = player.GetComponent<BasePlayer>().ReturnPlayerInventory();
            
            //fill empty inventory slot
            for(int i =0; i < playerInventory.Count; i++)
            {
                if (playerInventory[i].ItemName == "Empty")
                {
                    inventory_full = false;
                    playerInventory[i] = thisItem;
                    GameObject itemSlot = inventoryWindow.gameObject.transform.GetChild(i + 4).gameObject;
                    itemSlot.transform.GetChild(0).gameObject.SetActive(true);
                    itemSlot.name = "Empty";
                    break;
                }
            }

            //do not pick up if inventory is full
            if (!inventory_full)
            {
                inventoryWindow.gameObject.GetComponent<InventoryWindow>().RenewInventoryWindow();
                Destroy(this.gameObject);
            } 
        }   
    }

    private Sprite ReturnItemIcon(BaseItem item)
    {
        Sprite icon = new Sprite();
        Sprite[] spriteCollection = Resources.LoadAll<Sprite>("Sprites/Items");

        if (item.ItemType == BaseItem.ItemTypes.POTION)
            icon = spriteCollection[95];
        else if (item.ItemType == BaseItem.ItemTypes.QUESTITEM)
            icon = spriteCollection[53];
        else
            icon = spriteCollection[45];
   
        return icon;
    }
}
