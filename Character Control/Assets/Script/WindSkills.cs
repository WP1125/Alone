using UnityEngine;
using System.Collections;

public class WindSkills : AimingScript
{
    public LayerMask windLayerMask;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftClick();
        }
        if (Input.GetMouseButton(1))
        {
            rightClick();
        }
    }
    void leftClick()
    {
        Rigidbody2D change = closest();
        if (change != null) {
            Debug.Log(windStamina);
            windStamina -= 1;
            StartCoroutine(windStaminaRefill());
            if (change.gameObject.layer == 10)
            {
                Vector2 direction = getPushDirection();
                change.velocity = (direction * 10);
            }
        }

    }
    void rightClick()
    {
        Rigidbody2D change = closest();
        if (change != null)
        {
            if (change.gameObject.layer == 10)
            {
                Vector2 direction = getPullDirection();
                change.AddForce((direction * 50));
            }
        }
    }

    Rigidbody2D closest() {
        Vector2 pp = getMainPlayerPosition();
        Vector2 mp = getMousePosition();
        Vector2 rayCastDir = new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
        RaycastHit2D hit = Physics2D.Raycast(pp, rayCastDir, 10, windLayerMask);
        Debug.Log(hit.rigidbody);
        return hit.rigidbody;
    }
    Vector2 getPushDirection()
    {
        //Debug.Log(new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus())));
        return new Vector2(Mathf.Cos(getAnglePlus()), Mathf.Sin(getAnglePlus()));
    }
    Vector2 getPullDirection()
    {
        return new Vector2(Mathf.Cos(getAnglePlus()+Mathf.PI), Mathf.Sin(getAnglePlus()+Mathf.PI));
    }
}
