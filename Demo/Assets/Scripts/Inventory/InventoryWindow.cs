using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour {

	public int startingPositionX, startingPositionY;
	public int slotCount, slotCountLength;
    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    public GameObject draggedIcon;

	private int xPos, yPos;
    private GameObject itemSlot;
	private int slotCnt;
    private List<GameObject> inventorySlots;

    private List<BaseItem> playerInventory;

    void Start()
    {
        CreatInventorySlot();
        AddItemsFromInventory();
    }
	
    public void RenewInventoryWindow()
    {
        AddItemsFromInventory();
    }

    //draggable items, not yet inplemented
    public void ShowDraggedItem()
    {
        print("dragging");
        //draggedIcon.SetActive(true);
    }

    private void CreatInventorySlot()
    {
        inventorySlots = new List<GameObject>();
        xPos = startingPositionX;
        yPos = startingPositionY;

		for (int i = 0; i < slotCount; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            inventorySlots.Add(itemSlot);
            itemSlot.transform.SetParent(this.gameObject.transform);
			itemSlot.transform.localScale = new Vector3 (1, 1, 1);
			itemSlot.GetComponent<RectTransform> ().localPosition = new Vector3 (xPos, yPos, 0);

			xPos += (int) itemSlot.GetComponent<RectTransform> ().rect.width;
			slotCnt++;

			if (slotCnt % slotCountLength == 0) {
				slotCnt = 0;
				yPos -= (int) itemSlot.GetComponent<RectTransform> ().rect.width;
				xPos = startingPositionX;
			}
        }
    }

    private void AddItemsFromInventory()
    {
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
        for (int i =0; i < playerInventory.Count; i++)
        {
            if (inventorySlots[i].name == "Empty")
            {
                inventorySlots[i].name = i.ToString();
                //add icon;
                inventorySlots[i].transform.GetChild(0).gameObject.SetActive(true);
                inventorySlots[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ReturnItemIcon(playerInventory[i]);
            }
        }
    }

    private Sprite ReturnItemIcon(BaseItem item)
    {
        Sprite icon = new Sprite();
        Sprite [] spriteCollection = Resources.LoadAll<Sprite>("Sprites/Items");
        if (item.ItemType == BaseItem.ItemTypes.POTION)
        {
            //icon = Resources.Load<Sprite>("Sprites/Items/68043_95");
            icon = spriteCollection[95];
        }
        else if (item.ItemType == BaseItem.ItemTypes.QUESTITEM)
        {
            //icon = Resources.Load<Sprite>("Sprites/Items/68043_53");
            icon = spriteCollection[53];
        }
        else
        {
            //icon = Resources.Load<Sprite>("Sprites/Items/68043_45");
            icon = spriteCollection[45];
        }

        return icon;
    }
}
