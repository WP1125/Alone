using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {

    public GameObject[] ProtectedTargets;

    public GameObject[] resetObjects;
    public GameObject[] reactivateObjects;
    public Dictionary<GameObject, Vector3> resetPositions = new Dictionary<GameObject, Vector3>();
    public Dictionary<GameObject, bool> enableObjects = new Dictionary<GameObject, bool>();


    public Vector3 checkPointPos;
    public bool CheckPointHit = false;
    public bool PlayerDeath = false;

    void Awake()
    {
        foreach(GameObject obj in ProtectedTargets)
        {
            DontDestroyOnLoad(obj);
        }
    }

    void Update()
    {
        if (CheckPointHit)
         
        {
            CheckPointHit = false;
            foreach (GameObject g in resetObjects)
            {
                GameObject[] allG = GameObject.FindGameObjectsWithTag(g.tag);
                foreach (GameObject obj in allG)
                {
                    resetPositions.Add(obj,obj.transform.position);
                }

            }
            foreach (GameObject r in reactivateObjects)
            {
                enableObjects.Add(r, r.activeSelf);
            }
        }


        if (PlayerDeath)
        {
            GameObject.Find("Player").transform.position = checkPointPos ;
            foreach (GameObject obj in resetPositions.Keys)
            {
                obj.transform.position = resetPositions[obj];
            }
            foreach (GameObject r in enableObjects.Keys)
            {
                r.SetActive(enableObjects[r]);
            }
        }
    }


    

}
