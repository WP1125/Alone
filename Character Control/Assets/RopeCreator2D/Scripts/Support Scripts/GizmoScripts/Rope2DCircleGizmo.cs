using UnityEngine;

public class Rope2DCircleGizmo : MonoBehaviour {

    public bool showGizmo = true;
    public float gizmoRadius = 50f;
    public Color gizmoColor = Color.blue;

    void OnDrawGizmos()
    {
        if(showGizmo)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, gizmoRadius * transform.localScale.x);

        }

    }
}
