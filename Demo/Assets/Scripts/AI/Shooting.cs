using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    [Range(0,2)]
    public int projectileType;
    [Range(0,2)]
    public float shootingSpeed;
    public Vector2 projectileVelocity;
    public int projectileDamage;
    public Transform fireOrigin;
    public bool playerInRange;

    GameObject prefab;
    float lastShootTime;

	void Start () {
        if (projectileType == 0) // Normal Bullet
        {
            prefab = Resources.Load("Prefabs/Bullet") as GameObject;
        }
        else // Explosive
        {
            prefab = Resources.Load("Prefabs/Explosive") as GameObject;
        }

        lastShootTime = Time.time;
	}

    void Update()
    {
        if (playerInRange)
        {
            if (Time.time > lastShootTime + 1 * shootingSpeed)
            {
                GameObject projectile = Instantiate(prefab) as GameObject;
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                projectile.transform.position = fireOrigin.position;




                if (projectileType == 0) // Normal Bullet
                {
                    projectile.GetComponent<Bullet>().damage = projectileDamage;
                    if (GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x < 0)
                    {
                        rb.velocity = -projectileVelocity;
                    }
                    else
                    {
                        rb.velocity = projectileVelocity;
                    }
                    
                }
                else if (projectileType == 1) // Explosive Bullet
                {
                    projectile.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
                    ExplosiveController explosiveController = projectile.transform.GetChild(0).GetComponent<ExplosiveController>();
                    explosiveController.isProjectile = true;
                    explosiveController.explosionTimer = 0.05f;
                    if (GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x < 0)
                    {
                        rb.velocity = -projectileVelocity;
                    }
                    else
                    {
                        rb.velocity = projectileVelocity;
                    }
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                else // Explosive
                {
                    ExplosiveController explosiveController = projectile.transform.GetChild(0).GetComponent<ExplosiveController>();
                    explosiveController.explosionTimer = 1.2f;
                    explosiveController.decreaseHP(100);
                    if (GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x < 0)
                    {
                        rb.velocity = -projectileVelocity;
                    }
                    else
                    {
                        rb.velocity = projectileVelocity;
                    }
                }

                lastShootTime = Time.time;
            }
        }
    }
}
