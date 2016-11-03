using UnityEngine;
using System.Collections;

public class Elemental : MonoBehaviour
{

    public ArrayList elemental;
    public string currentWeapon;
    public int currentWeaponint;
    public GameObject[] elements;
    public bool available3; //if weapon 3 is available
    public bool available4; //if weapon 4 is available
    // Use this for initialization
    void Start()
    {
        currentWeaponint = 0;
        changeWeapon(currentWeaponint);
        //available3 = false;
        //available4 = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && available3)
        {
            changeWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && available4)
        {
            changeWeapon(3);
        }
    }
    public void changeWeapon(int num)
    {
        currentWeaponint= num;
        for (int i = 0; i < elements.Length; i++)
        {
            if (i == num)
                elements[i].gameObject.SetActive(true);
            else
                elements[i].gameObject.SetActive(false);
        }
    }
    
}