using UnityEngine;
using System.Collections;

public class Ground_Chaser : MonoBehaviour
{
    public Transform[] patrol;
    private int current_location;
    public float patrol_speed;

    public GameObject target;
    private float chaser_to_target_distance_x;
    private float chaser_to_target_distance_y;
    private float chaser_to_target_distance_z;
    public float detection_x;
    public float detection_y;
    public float detection_z;
    public float chaser_speed;
    private bool patroling;


    void Start()
    {
        patroling = true;
        transform.position = patrol[0].position;
        current_location = 0;
    }

    void Update()
    {
        chaser_to_target_distance_x = Mathf.Abs(target.transform.position.x - transform.position.x);
        chaser_to_target_distance_y = Mathf.Abs(target.transform.position.y - transform.position.y);
        chaser_to_target_distance_z = Mathf.Abs(target.transform.position.z - transform.position.z);
        Vector3 distance = new Vector3(chaser_to_target_distance_x, chaser_to_target_distance_y, chaser_to_target_distance_z);
        Vector3 detection_vector = new Vector3(detection_x, detection_y, detection_z);
        if (!patroling)
        {
            if (distance.x > detection_vector.x || distance.y > detection_vector.y)
            {
                patroling = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, chaser_speed * Time.deltaTime);
        }
        if (patroling)
        {
            if (transform.position == patrol[current_location].position)
            {
                //transform.Rotate(0, 0, 180);
                current_location++;

            }

            if (current_location >= patrol.Length)
            {
                //transform.Rotate(0, 0, -180);
                current_location = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, patrol[current_location].position, patrol_speed * Time.deltaTime);




            if (distance.x < detection_vector.x && distance.y < detection_vector.y)
            {
                patroling = false;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, chaser_speed * Time.deltaTime);
            }

        }


    }
}  
