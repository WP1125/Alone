using UnityEngine;
using System.Collections;

public class LightningSkills : AimingScript {

    public LayerMask lightningLayerMask;
    public static int lightningStamina;
    private int lightningStaminaFull;
    private float lightningRechargeTime;
    private bool lightningButtonDown;
    private float lightningChargesTaken;
    private float chargeTime;
    private float fullChargeTime;
    private float lightningFullRequirement;
    // Use this for initialization
    void Start()
    {
        lightningStaminaFull = 60;
        lightningStamina = lightningStaminaFull;
        lightningRechargeTime = 0.5f;
        InvokeRepeating("Recharge", 0, lightningRechargeTime);
        lightningButtonDown = false;
        lightningChargesTaken = 0.5f;
        lightningFullRequirement = 0.75f;
        fullChargeTime = 5f;
        chargeTime = 0;
    }

    void OnEnable()
    {
        MaxDistance = 20;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(lightningStamina);
            if (lightningStamina > lightningStaminaFull*lightningChargesTaken) { leftClick(); }
        }
        if (Input.GetMouseButton(1) && lightningStamina>lightningStaminaFull*lightningFullRequirement)
        {
            chargeTime += Time.deltaTime;
            lightningButtonDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            rightClick(chargeTime);
            chargeTime = 0;
            lightningButtonDown = false;
        }
    }
    void leftClick()
    {
        Rigidbody2D change = closest();
        lightningStamina -= (int)(lightningStaminaFull * lightningChargesTaken);
        if (change != null)
        {
            //what can be lightnified (if that's a word)
            if (change.gameObject.layer == 10)
            {
                //Tons of damage
            }
        }
    }

    void rightClick(float chargeTime)
    {
        //Debug.Log(chargeTime);
        if (chargeTime > fullChargeTime)
        {
            //Debug.Log("Fire full lightning");
        }
    }

    void Recharge()
    {
        //Debug.Log(Time.time);
        if (lightningStamina < lightningStaminaFull && !lightningButtonDown)
        {
            lightningStamina += 1;
            //Debug.Log("Lightning Stamina:" + lightningStamina);
        }
    }

    Rigidbody2D closest()
    {
        Vector2 pp = getMainPlayerPosition();
        //Vector2 mp = getMousePosition();
        Vector2 rayCastDir = new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
        RaycastHit2D hit = Physics2D.Raycast(pp, rayCastDir, MaxDistance, lightningLayerMask);
        //Debug.Log(hit.rigidbody);
        return hit.rigidbody;
    }
}
