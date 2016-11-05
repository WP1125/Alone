using UnityEngine;
using System.Collections;

public class ExplosiveController : MonoBehaviour {

    public GameObject targetExplosive;
    private BasePlayer player;
    public CircleCollider2D impactArea;

    public int itemHP = 20;
    public int explosionDamage;

    public float explosionTimer = 0.05f;
    private float explosionTime;
    private bool explodeSignal;
    private bool playerInRange;

    public bool isProjectile;
    public int playerColliderCount;
    int collisionCount;


    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<BasePlayer>();
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

    public void decreaseHP(int amount)
    {
        itemHP -= amount;
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
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            collisionCount += 1;

            if (collisionCount == playerColliderCount)
            {
                playerInRange = true;
                if (isProjectile)
                {
                    decreaseHP(itemHP);
                }

            }
        }
        else
        {
            decreaseHP(itemHP);
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
