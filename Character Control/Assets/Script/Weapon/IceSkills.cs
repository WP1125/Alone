using UnityEngine;
using System.Collections;

public class IceSkills : AimingScript {

    public LayerMask iceLayerMask;
    public static int iceStamina;
    private int iceStaminaFull;
    private float iceRechargeTime;
    private bool iceButtonDown;
    private float iceChargesTaken;
    private float iceDepleteRate;
	// Use this for initialization
	void Start () {
        iceStaminaFull = 60;
        iceStamina = iceStaminaFull;
        iceRechargeTime = 0.5f;
        InvokeRepeating("Recharge", 0, iceRechargeTime);
        iceButtonDown = false;
        iceChargesTaken = 0.25f;
        iceDepleteRate = 0.2f;
    }

    void OnEnable()
    {
        MaxDistance = 5;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (iceStamina > (int)(iceStaminaFull*iceChargesTaken)) { leftClick(); }
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(rightClick());
            iceButtonDown = true;
            PlayerPrefs.Save();
        }
        if (Input.GetMouseButtonUp(1))
        {
            iceButtonDown = false;
        }
    }
    void leftClick()
    {
        Rigidbody2D change = closest();
        iceStamina -= (int)(iceStaminaFull / 4);
        if (change != null)
        {
            
            //what can be iced
            if (change.gameObject.layer == 10)
            {
                //freeze gameobject
            }
        }
    }
    IEnumerator rightClick()
    {
        StartCoroutine("Ice");
        while (Input.GetMouseButton(1))
        {
            iceStamina -= 1;
            yield return new WaitForSeconds(iceDepleteRate);
            //Debug.Log("IceStamina:" +iceStamina);
            if (iceStamina <= 0)
            {
                StopCoroutine("Ice");
                break;
            }
        }
        //Debug.Log("Stop");
        StopCoroutine("Ice");
        yield return null;
    }

    IEnumerator Ice()
    {
        while (true)
        {
            Rigidbody2D change = closest();
            if (change != null)
            {
                //what can be iced
                if (change.gameObject.layer == 10)
                {
                    Debug.Log("freezing" + change);
                    //slowly freeze gameobject
                }
            }
            yield return null;
        }
    }

    void Recharge()
    {
        if (iceStamina < iceStaminaFull && !iceButtonDown)
        {
            iceStamina += 1;
            //Debug.Log("iceStamina: " + iceStamina);
        }
    }

    Rigidbody2D closest()
    {
        Vector2 pp = getMainPlayerPosition();
        //Vector2 mp = getMousePosition();
        Vector2 rayCastDir = new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
        RaycastHit2D hit = Physics2D.Raycast(pp, rayCastDir, MaxDistance, iceLayerMask);
        //Debug.Log(hit.rigidbody);
        return hit.rigidbody;
    }
}
