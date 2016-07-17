using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePlayer : MonoBehaviour {

    [Range(0,100)]
	public int playerHP;
	public int playerStamina;
    //private List<BaseStat> _playerStats = new List<BaseStat>();
    private List<BaseItem> _inventory = new List<BaseItem>();

	// Use this for initialization
	void Start () {
	    for (int i=0; i < 21; i++)
        {
            BaseItem _item = new BaseItem();
            _inventory.Add(_item);
            //Debug.Log(_inventory[i].ItemName);
            //Debug.Log(_inventory[i].ItemDescription);
            //Debug.Log(_inventory[i].ItemValue);
            //Debug.Log(_inventory[i].ItemType);
            //Debug.Log(_inventory[i].ItemStat[0].StatName);
            //Debug.Log(_inventory[i].ItemStat[0].StatDescription);
            //Debug.Log(_inventory[i].ItemStat[0].StatType);
        }
	}

    public void increaseHP(int amount)
    {
        playerHP += amount;
        if(playerHP > 100)
        {
            playerHP = 100;
        }
    }

    public List<BaseItem> ReturnPlayerInventory()
    {
        return _inventory;
    }
}
