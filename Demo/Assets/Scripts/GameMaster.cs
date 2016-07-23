using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public GameObject[] ProtectedTargets;

    void Awake()
    {
        foreach(GameObject obj in ProtectedTargets)
        {
            DontDestroyOnLoad(obj);
        }
    }

}
