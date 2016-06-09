using UnityEngine;
using System.Collections;

public class WindSkills : AimingScript
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            leftClick();
        }
    }
    void leftClick() {
        Vector2 pp=getMainPlayerPosition();
        Vector2 mp=getMousePosition();
        float angle = getAnglePlus();
        Collider2D[] z=Physics2D.OverlapAreaAll (new Vector2(pp.x + Mathf.Sin(angle), pp.y - Mathf.Cos(angle)), new Vector2(pp.x - Mathf.Sin(angle) * MaxDistance, pp.y + Mathf.Cos(angle) * MaxDistance));
        Vector2 tp= new Vector2(MaxDistance * Mathf.Cos(angle) + MainPlayer.transform.position.x, MaxDistance * Mathf.Sin(angle) + MainPlayer.transform.position.y);
        Debug.Log(new Vector2(pp.x + Mathf.Sin(angle), pp.y - Mathf.Cos(angle)));
        Debug.Log(new Vector2(tp.x - Mathf.Sin(angle), tp.y + Mathf.Cos(angle)));
        print(z.Length);
        for (int i = 0; i < z.Length; i++) {
            Debug.Log(z[i]);
        }
    }

}
