using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseItem {

    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public int ItemID { get; set; }
    public int ItemValue;
    public ItemTypes ItemType { get; set; }
    public List<BaseStat> ItemStat { get; set; }

    public enum ItemTypes
    {
        POTION,
        QUESTITEM,
        COLLECTABLE
    }

    //generate a random item
    public BaseItem()
    {
        ItemName = "Item" + Random.Range(0, 101);
        ItemDescription = ItemName + " is an awsome item!";
        ItemValue = Random.Range(10, 500);
        ChooseType();
        ItemStat = new List<BaseStat>();
        ItemStat.Add(new BaseStamina());
        ItemStat.Add(new BaseHP());
    }

    private void ChooseType()
    {
        int type = Random.Range(0, 3);
        if (type == 0)
        {
            ItemType = ItemTypes.POTION;
        }else if(type == 1)
        {
            ItemType = ItemTypes.COLLECTABLE;
        }
        else
        {
            ItemType = ItemTypes.QUESTITEM;
        }
    }
    
}
