using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyController : MonoBehaviour {
    public int numKeysRequired;
    private List<BaseItem> playerInventory;
    public InventoryWindow inventoryWindow;
    public bool allKeysAquired;

    // Use this for initialization
    void Start () {
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
        allKeysAquired = false;
    }
	
    public bool HasAllKeys()
    {
        int keyCount = 0;
        List<int> toDelete = new List<int> (numKeysRequired);

        //BaseItem item;
        for (int i=0; i< playerInventory.Count; i++)
        {
            if (playerInventory[i].ItemName == "Key")
            {
                keyCount++;
                toDelete.Add(i);
            }
        }
        if (keyCount == numKeysRequired)
        {
            foreach (int index in toDelete)
            {
                playerInventory[index].ItemName = "Empty";
                inventoryWindow.ActivateSlot(index, false);
            }
            allKeysAquired = true;
        }

        return allKeysAquired;
    }
}
