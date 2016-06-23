using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour
{
    public GameObject target;


    void Update()
    {

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

    }

}