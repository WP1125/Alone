using UnityEngine;
using System.Collections;



[RequireComponent(typeof(Rigidbody2D))]
public class SceneController : MonoBehaviour {

    public string nextScene;
    private bool loadSceneEnable;

    void Start()
    {
        loadSceneEnable = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& loadSceneEnable)
        {
            Application.LoadLevel(nextScene);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player"){
            loadSceneEnable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            loadSceneEnable = false;
        }
    }
}
