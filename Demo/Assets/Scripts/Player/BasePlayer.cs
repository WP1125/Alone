using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePlayer : MonoBehaviour {

    public GameObject player;
    [Range(0, 100)]
	public float playerHP;
	public int playerStamina;
    bool overtimeEffects;
    float effectsDuration;
    float HPPerSecond;
    //private List<BaseStat> _playerStats = new List<BaseStat>();
    private List<BaseItem> _inventory = new List<BaseItem>();


	void Start () {
	    for (int i=0; i < 21; i++)
        {
            BaseItem _item = new BaseItem();
            _inventory.Add(_item);
        }
	}

    void Update()
    {
        if (playerHP == 0f)
        {
            Debug.Log("Game Over! You are dead :(");

            player.GetComponent<Player>().enabled = false;
            //player.SetActive(false);
        }
        else if (playerHP < 20f && HPPerSecond == 0f)
        {
            playerHP += 1f * Time.deltaTime;
        }
        ModifyHP(HPPerSecond, effectsDuration);
    }

    public void ModifyHP(float amount, float duration = 0f)
    {
        if (duration == 0f)
        {
            if (overtimeEffects == false)
                playerHP += amount;
            else
                overtimeEffects = false;
            HPPerSecond = 0f;
        }
        else if (duration > 0f)
        {
            overtimeEffects = true;
            effectsDuration = duration;
            HPPerSecond = amount;

            playerHP += amount * Time.deltaTime;

            effectsDuration -= Time.deltaTime;
        }

        if (playerHP > 100f)
            playerHP = 100f;
        else if (playerHP < 0f)
            playerHP = 0f;
    }

    public List<BaseItem> ReturnPlayerInventory()
    {
        return _inventory;
    }
}
