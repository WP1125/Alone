using UnityEngine;
using System.Collections;

public class AimingScript : MonoBehaviour {
    public static Vector3 MousePosition;
    public static Vector2 diffInAngle;
    public static int MaxDistance;
    public static GameObject MainPlayer;
    // Use this for initialization
    void Start () {
        MainPlayer = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    public static float getDistance(Vector2 x, Vector2 y)
    {
        return Vector2.Distance(x, y);
    }

    public static float getAngle(Vector2 x, Vector2 y)
    {
        diffInAngle = y - x;
        return Mathf.Atan2(diffInAngle.y, diffInAngle.x);
    }

    public static float getDistancePlus()
    {
        return getDistance((Vector2)MainPlayer.transform.position, (Vector2)MousePosition);
    }

    public static float getAnglePlus()
    {
        return getAngle((Vector2)MainPlayer.transform.position, (Vector2)MousePosition);
    }
    public static Vector2 getMousePosition()
    {
        return (Vector2)MousePosition;
    }

    public static Vector2 getMainPlayerPosition()
    {
        return (Vector2)MainPlayer.transform.position;
    }
}
