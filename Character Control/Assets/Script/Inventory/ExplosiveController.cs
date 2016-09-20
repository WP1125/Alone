using UnityEngine;
using System.Collections;

public class ExplosiveController : MonoBehaviour {

    //public GameObject targetExplosive;
    public BasePlayer player;
    public CircleCollider2D impactArea;
    public GameObject ExplosionPart;

    public int itemHP = 20;
    public int explosionDamage;
    

    public float explosionTimer = 0.5f;
    private float explosionTime;
    private bool explodeSignal;
    private bool playerInRange;
    private bool exploding = false;

    public bool startTime = false;
    


    void Start () {
        playerInRange = false;
        impactArea.enabled = false;
        explodeSignal = false;
	}
	
	void Update () {
	    if (itemHP <= 20)
        {
            impactArea.enabled = true;

            if (explodeSignal == false && startTime)
            {
                Debug.Log("StartExplode");
                explodeSignal = true;
                explosionTime = Time.time + explosionTimer;
            }

            Debug.Log(explosionTime);
            
            if (explosionTime <= Time.time && startTime)
            {
                Debug.Log("Explode");
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
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(ExplosionPart, transform.position, Quaternion.identity);
        exploding = true;
        
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }

        if (exploding)
        {
            if (other.gameObject.tag == "Break")
            {
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }

        if (exploding)
        {
            if (other.gameObject.tag == "Break")
            {
                Destroy(other.gameObject);
            }
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
