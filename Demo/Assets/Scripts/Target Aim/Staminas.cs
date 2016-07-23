using UnityEngine;
using System.Collections;

public class Staminas : MonoBehaviour {
    public int mainStamina;
    public int windStamina;
    private float windTime;
    // Use this for initialization
    void Awake() {
        windStamina = 3;
    }
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public IEnumerator windStaminaRefill() {
        Debug.Log(windStamina);
        yield return new WaitForSeconds(5);
        if (windStamina < 3) {
            windStamina += 1;
            Debug.Log(windStamina);

        }
        StopCoroutine(windStaminaRefill());
    }

}
