using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public GameObject door;
    public float closeTimer;
    private float timeLeft;
    private bool timerStart;


    void Start()
    {
        timerStart = false;
        timeLeft = closeTimer;
    }

    void Update()
    {
        if (timerStart && timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
        }

        if(timeLeft <= 0)
        {
            timerStart = false;
            timeLeft = closeTimer;
            door.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.name == "Player" || other.gameObject.tag == "PickUp")
        {
            timerStart = false;
            timeLeft = closeTimer;
            door.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.tag == "PickUp")
        {
            timerStart = true;
        }
    }
}
