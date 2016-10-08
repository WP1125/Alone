using UnityEngine;

//if you attach it to the ropeBit prefabs, you can cut the rope with the mouse. (click / click & hold the mouse button on the rope)

public class Rope2DMouseCutter : MonoBehaviour {

    void OnMouseOver()
    {
        if(Input.GetMouseButton(1) || Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }
}
