using UnityEngine;
using System.Collections;

public class ExplosiveController : MonoBehaviour {

    public GameObject targetExplosive;
    public BasePlayer player;
    public CircleCollider2D impactArea;

    public int itemHP = 20;
    public int explosionDamage;

    public float explosionTimer = 0.5f;
    private float explosionTime;
    private bool explodeSignal;
    private bool playerInRange;


    void Start () {
        playerInRange = false;
        impactArea.enabled = false;
        explodeSignal = false;
	}
	
	void Update () {
	    if (itemHP <= 0)
        {
            impactArea.enabled = true;

            if (explodeSignal == false)
            {
                explodeSignal = true;
                explosionTime = Time.time + explosionTimer;
            }

            if (explosionTime <= Time.time)
            {
                explode();
            }
        }

	}

    void explode()
    {
        if (playerInRange)
        {
            player.deceaseHP(explosionDamage);
        }
        Destroy(targetExplosive);
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        print("stay");
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = false;
        }
    }
}
