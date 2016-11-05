

[System.Serializable]
public class BaseStamina : BaseStat {

	public BaseStamina()
    {
        StatName = "Statnima";
        StatDescription = "Determines players ability to perform actions";
        StatType = StatTypes.STAMINA;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
