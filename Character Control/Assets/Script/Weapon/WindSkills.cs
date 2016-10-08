using UnityEngine;
using System.Collections;

public class WindSkills : AimingScript
{
    public LayerMask windLayerMask;
    public static int windStamina;
    private int windStaminaFull;
    private float windRechargeTime;
    private bool windButtonDown;
    private float windChargesTaken;
    private float windDepleteRate;
    private float pullForce;
    private float pushForce;
    // Use this for initialization
    void Start()
    {
        windStaminaFull = 60;
        windStamina = windStaminaFull;
        windRechargeTime = 0.5f;
        InvokeRepeating("Recharge", 0, windRechargeTime);
        windButtonDown = false;
        windChargesTaken = 0.33f;
        windDepleteRate = 0.2f;
        pullForce = 80;
        pushForce = 20;
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
            if (windStamina > (int)(windStaminaFull*windChargesTaken)) { leftClick(); }
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(rightClick());
            windButtonDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            windButtonDown = false;
        }

    }
    void leftClick()
    {
        
        Rigidbody2D change = closest();
        windStamina -= (int)(windStaminaFull/3);
        if (change != null) {
            
            //what can be pushed
            if (change.gameObject.layer == 10)
            {
                Vector2 direction = getPushDirection();
                change.velocity = (direction * pushForce);
            }
        }
    }
    IEnumerator rightClick()
    {
        StartCoroutine("Pull");
        while (Input.GetMouseButton(1))
        {
            windStamina -= 1;
            yield return new WaitForSeconds(windDepleteRate);
            //Debug.Log(windStamina);
            if (windStamina <= 0)
            {
                StopCoroutine("Pull");
                break;
            }
            //Debug.Log(windStamina);
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
                    change.AddForce((direction * pullForce));
                }
            }
            yield return null;
        }
    }

    void Recharge()
    {
        //Debug.Log(Time.time);
        if (windStamina < windStaminaFull && !windButtonDown)
        {
            windStamina += 1;
            //Debug.Log("Wind Stamina:" + windStamina);
        }
    }
    Rigidbody2D closest()
    {
        Vector2 pp = getMainPlayerPosition();
        //Vector2 mp = getMousePosition();
        Vector2 rayCastDir = new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
        RaycastHit2D hit = Physics2D.Raycast(pp, rayCastDir, MaxDistance, windLayerMask);
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
        return new Vector2(Mathf.Cos(getAnglePlus()+Mathf.PI), Mathf.Sin(getAnglePlus()+Mathf.PI));
    }
}
