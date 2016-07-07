using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour {

	public int startingPositionX, startingPositionY;
	public int slotCount, slotCountLength;
    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

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
	
	void Update () {
        
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
            }
        }
    }
}
