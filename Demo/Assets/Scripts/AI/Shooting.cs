using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    [Range(0,3)]
    public int projectileType;
    [Range(0,2)]
    public float shootingSpeed;
    public Vector2 projectileVelocity;
    public int projectileDamage;
    public Transform fireOrigin;

    GameObject prefab;
    float lastShootTime;

	// Use this for initialization
	void Start () {
        prefab = Resources.Load("Prefabs/Bullet") as GameObject;
        lastShootTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > lastShootTime + 1 * shootingSpeed)
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.GetComponent<Bullet>().damage = projectileDamage;
            projectile.transform.position = fireOrigin.position;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = projectileVelocity;

            lastShootTime = Time.time;
        }
	}
}
