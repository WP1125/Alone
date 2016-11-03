using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public static int level;
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

   
    
	// Update is called once per frame
	void Update () {
	
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        PlayerData data = new PlayerData();
        data.SerializbleVector3(gameObject.transform.position);

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("save");
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            Debug.Log("load");
            gameObject.transform.position = data.GetVector3();

        }
    }
}

[Serializable]
class PlayerData
{
    //public Vector3 playerPosition;

    public float x;
    public float y;
    public float z;
    public void SerializbleVector3(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }
    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }

}