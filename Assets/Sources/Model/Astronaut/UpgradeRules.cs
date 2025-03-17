public class UpgradeRules
{
    public int HealthIncrement { get; }
    public int HealthCost { get; }

    public float SpeedIncrement { get; }
    public int SpeedCost { get; }

    public int CapacityIncrement { get; }
    public int CapacityCost { get; }

    public UpgradeRules(int healthIncrement, int healthCost, float speedIncrement, int speedCost, int capacityIncrement, int capacityCost)
    {
        HealthIncrement = healthIncrement;
        HealthCost = healthCost;
        SpeedIncrement = speedIncrement;
        SpeedCost = speedCost;
        CapacityIncrement = capacityIncrement;
        CapacityCost = capacityCost;
    }
}
