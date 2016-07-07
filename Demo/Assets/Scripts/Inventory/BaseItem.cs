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

    public BaseItem()
    {
        ItemName = "Item" + Random.Range(0, 101);
        ItemDescription = ItemName + " is an awsome item!";
        ItemValue = Random.Range(10, 500);
        ItemType = ItemTypes.POTION;
        ItemStat = new List<BaseStat>();
        ItemStat.Add(new BaseStamina());
        ItemStat.Add(new BaseHP());
    }

    
}
