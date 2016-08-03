using UnityEngine;
using System.Collections;

public class Staminas : MonoBehaviour {
    //private int mainStamina;
    public int windStamina;
    public int iceStamina;
    public int windStaminaFull;
    public int iceStaminaFull;
    private float windRechargeTime;
    private float iceRechargeTime;
    /*
    // Use this for initialization
    void Awake() {
        windStaminaFull = 60;
        //windStamina = windStaminaFull;
        windRechargeTime = 0.5f;
        StartCoroutine(windStaminaRefill());
        iceStaminaFull = 60;
        iceStamina = iceStaminaFull;
        iceRechargeTime = 0.5f;
        StartCoroutine(iceStaminaRefill());
    }
	void Start () {
        windStamina = 30;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public IEnumerator windStaminaRefill() {
        while (true)
        {
            //Debug.Log(windStamina);
            if (windStamina < windStaminaFull) {
                //Debug.Log(windStamina);
                yield return new WaitForSeconds(windRechargeTime);
                windStamina += 1;
                Debug.Log("WindStamina: " + windStamina);
            }
            yield return null;
        }
    }
    public IEnumerator iceStaminaRefill()
    {
        
        while (true)
        {
            if (iceStamina < iceStaminaFull)
            {
                yield return new WaitForSeconds(iceRechargeTime);
                iceStamina += 1;
                Debug.Log("IceStamina: " + iceStamina);
            }

            yield return null;
        }
        //StopCoroutine(windStaminaRefill());
    }
    */
}
