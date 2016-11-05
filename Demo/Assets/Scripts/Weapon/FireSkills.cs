using UnityEngine;
using System.Collections;

public class FireSkills : AimingScript
{
    public LayerMask fireLayerMask;
    public static int fireStamina;
    private int fireStaminaFull;
    private float fireRechargeTime;
    private bool fireButtonDown;
    private float fireChargesTaken;
    private float fireDepleteRate;
    // Use this for initialization
    void Start()
    {
        fireStaminaFull = 60;
        fireStamina = fireStaminaFull;
        fireRechargeTime = 0.5f;
        InvokeRepeating("Recharge", 0, fireRechargeTime);
        fireButtonDown = false;
        fireChargesTaken = 0.2f;
        fireDepleteRate = 0.2f;
    }

    void OnEnable()
    {
        MaxDistance = 10;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (fireStamina > (int)(fireStaminaFull * fireChargesTaken)) { leftClick(); }
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(rightClick());
            fireButtonDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            fireButtonDown = false;
        }

    }
    void leftClick()
    {

        Rigidbody2D change = closest();
        fireStamina -= (int)(fireStaminaFull / 3);
        if (change != null)
        {

            //launch fire ball
            Debug.Log("launchfireball");
        }
    }
    IEnumerator rightClick()
    {
        StartCoroutine("Pull");
        while (Input.GetMouseButton(1))
        {
            fireStamina -= 1;
            yield return new WaitForSeconds(fireDepleteRate);
            //Debug.Log(fireStamina);
            if (fireStamina <= 0)
            {
                StopCoroutine("Pull");
                break;
            }
            //Debug.Log(fireStamina);
        }
        //Debug.Log("Stop");
        StopCoroutine("Pull");
        yield return null;
    }
    IEnumerator Pull()
    {
        while (true)
        {
            Rigidbody2D change = closest();
            if (change != null)
            {
                //what can be pulled
                if (change.gameObject.layer == 10)
                {
                    Vector2 direction = getPullDirection();
                    change.AddForce((direction * 50));
                }
            }
            yield return null;
        }
    }

    void Recharge()
    {
        //Debug.Log(Time.time);
        if (fireStamina < fireStaminaFull && !fireButtonDown)
        {
            fireStamina += 1;
            //Debug.Log("Fire Stamina:" + fireStamina);
        }
    }
    Rigidbody2D closest()
    {
        Vector2 pp = getMainPlayerPosition();
        //Vector2 mp = getMousePosition();
        Vector2 rayCastDir = new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
        RaycastHit2D hit = Physics2D.Raycast(pp, rayCastDir, MaxDistance, fireLayerMask);
        //Debug.Log(hit.rigidbody);
        return hit.rigidbody;
    }

    Vector2 getPushDirection()
    {
        //Debug.Log(new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus())));
        return new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
    }
    Vector2 getPullDirection()
    {
        return new Vector2(Mathf.Cos(getAnglePlus() + Mathf.PI), Mathf.Sin(getAnglePlus() + Mathf.PI));
    }
}
