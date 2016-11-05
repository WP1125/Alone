using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

    void OnGUI()
    {
        
        if (GUI.Button(new Rect(10, 10, 100, 30), "Save"))
        {
            GameControl.control.Save();
        }
        if (GUI.Button(new Rect(10, 40, 100, 30), "Load"))
        {
            GameControl.control.Load();
        }
        
        GUI.Label(new Rect(400, 10, 200, 20), "WindStamina: " + WindSkills.windStamina);
        GUI.Label(new Rect(400, 30, 200, 20), "IceStamina: " + IceSkills.iceStamina);
        GUI.Label(new Rect(400, 50, 200, 20), "LightningStamina: " + LightningSkills.lightningStamina);
        GUI.Label(new Rect(400, 70, 200, 20), "FireStamina: " + FireSkills.fireStamina);
    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
