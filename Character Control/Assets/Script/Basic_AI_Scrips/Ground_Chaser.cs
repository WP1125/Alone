using UnityEngine;
using System.Collections;

public class Ground_Chaser : MonoBehaviour
{
    public GameObject target;
    public float chaser_speed;
    public float detection;
    private float chaser_to_target_distance;
    private bool chasing;



    public GameObject Bullet;
    public GameObject Bullet_Emitter;
    public float Bullet_Forward_Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chaser_to_target_distance = Mathf.Abs(target.transform.position.x - transform.position.x);
        if (chaser_to_target_distance < detection)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, chaser_speed);
            if (Input.GetKeyDown("space"))
            {
                //The Bullet instantiation happens here.
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody2D Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_Handler, 5.0f);
            }

        }
    }


    





}
