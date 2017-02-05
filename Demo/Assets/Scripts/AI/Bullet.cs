using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int damage;
    BasePlayer player;
    public int playerColliderCount;
    int collisionCount;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<BasePlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            collisionCount += 1;
            if (collisionCount == playerColliderCount)
            {
                Destroy(this.gameObject);
                player.ModifyHP(-damage);
            }
        }
        else if (other.gameObject.name == "Explosive")
        {
            other.gameObject.transform.GetChild(0).GetComponent<ExplosiveController>().decreaseHP(damage);
            Destroy(this.gameObject);
        }

        else
            Destroy(this.gameObject);
    }


}