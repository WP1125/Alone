using UnityEngine;
using System.Collections;

public class BaseStat : MonoBehaviour {
    /*
    private string _name;
    private string _description;
    private float _baseValue;
    private float _modifiedValue;
    private StatTypes _type;
    */

    public enum StatTypes
    {
        STAMINA,
        HP
    }

    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public float StatBaseValue { get; set; }
    public float StatModifiedValue { get; set; }
    public StatTypes StatType { get; set; }
}
