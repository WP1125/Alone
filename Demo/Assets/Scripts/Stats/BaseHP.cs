

[System.Serializable]
public class BaseHP : BaseStat {

    public BaseHP()
    {
        StatName = "HP";
        StatDescription = "Determines player's HP";
        StatType = StatTypes.HP;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
