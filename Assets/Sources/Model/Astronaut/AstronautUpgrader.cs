using System;

public class AstronautUpgrader
{
    private readonly UpgradeRules _upgradeRules;
    private readonly Storage _storage;

    public AstronautUpgrader(UpgradeRules upgradeRules, Storage storage)
    {
        _upgradeRules = upgradeRules;
        _storage = storage;
    }

    public bool TryUpgradeHealth(IUpgradable upgradable)
    {
        return TryUpgrade(
            () => upgradable.TryUpgradeHealth(_upgradeRules.HealthIncrement),
            _upgradeRules.HealthCost
        );
    }

    public bool TryUpgradeSpeed(IUpgradable upgradable)
    {
        return TryUpgrade(
            () => upgradable.TryUpgradeSpeed(_upgradeRules.SpeedIncrement),
            _upgradeRules.SpeedCost
        );
    }

    public bool TryUpgradeCapacity(IUpgradable upgradable)
    {
        return TryUpgrade(
            () => upgradable.TryUpgradeCapacity(_upgradeRules.CapacityIncrement),
            _upgradeRules.CapacityCost
        );
    }

    private bool TryUpgrade(Func<bool> upgradeAction, int cost)
    {
        if (_storage.TrySpendResourceScore(cost))
            return upgradeAction.Invoke();

        return false;
    }
}
