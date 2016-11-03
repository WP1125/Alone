using UnityEngine;
using System.Collections;

public class ElementalScroll : MonoBehaviour
{

    public ArrayList elemental;
    public float scroll; //scroll input
    public string currentWeapon;
    public int currentWeaponint;
    public GameObject[] elements;
    public bool available3; //if weapon 3 is available
    public bool available4; //if weapon 4 is available
    public bool scrollable;
    // Use this for initialization
    void Start()
    {
        currentWeaponint = 0;
        available3 = false;
        available4 = false;
        scrollable = true;

    }

    // Update is called once per frame
    void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        StartCoroutine(Scrolling(0.5f));
    }

    void FixedUpdate()
    {
    }
    public void changeWeapon(int num)
    {
        if (currentWeaponint == 0 && num == -1)
        {
            currentWeaponint = 3;
        }
        else if (currentWeaponint == 3 && num == 1)
        {
            currentWeaponint = 0;
        }
        else {
            currentWeaponint = currentWeaponint + num;
        }
        for (int i = 0; i < elements.Length; i++)
        {
            if (i == currentWeaponint)
                elements[i].gameObject.SetActive(true);
            else
                elements[i].gameObject.SetActive(false);
        }
    }
    IEnumerator Scrolling(float waitTime)
    {
        while (true)
        {
            if (scroll > 0 && scrollable==true)
            {
                Debug.Log("Scrollup");
                changeWeapon(1);
                scrollable = false;
                yield return new WaitForSeconds(waitTime);
            }
            else{
                if (Time.deltaTime > Time.deltaTime + waitTime) {
                    scrollable = true;
                }
                yield return null;
            }

            if (scroll < 0)
            {
                Debug.Log("ScrollDown");
                changeWeapon(-1);
                scrollable = false;
                yield return new WaitForSeconds(waitTime);
            }
            else {
                if (Time.deltaTime > Time.deltaTime + waitTime)
                {
                    scrollable = true;
                }
                yield return null;
            }
                
            }
        }

    }
