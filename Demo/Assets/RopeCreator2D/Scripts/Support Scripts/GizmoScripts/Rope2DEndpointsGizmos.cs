using UnityEngine;
using System.Collections;

public class Rope2DEndpointsGizmos : MonoBehaviour {

    public float gizmoRadius = 0.1f;
    public Color baseColor = Color.white;
    public Color selectingColor = Color.green;


    void OnDrawGizmos()
    {
        Gizmos.color = baseColor;
        Gizmos.DrawSphere(transform.position, gizmoRadius);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = selectingColor;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }

}
