public interface IUpgradable
{
    public bool TryUpgradeHealth(int amount);
    public bool TryUpgradeSpeed(float amount);
    public bool TryUpgradeCapacity(int amount);
}
