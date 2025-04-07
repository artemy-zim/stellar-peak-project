public class AstronautStats : IReadOnlyAstronautStats, IUpgradable
{
    private readonly float _maxSpeed;
    private readonly int _maxHealth;
    private readonly float _maxCapacity;

    private float _speed;
    private int _capacity;
    private int _health;


    public AstronautStats(float speed, int capacity, int health, float maxSpeed, int maxHealth, int maxCapacity)
    {
        _speed = speed;
        _capacity = capacity;
        _health = health;

        _maxSpeed = maxSpeed;
        _maxHealth = maxHealth;
        _maxCapacity = maxCapacity; 
    }

    public float Speed => _speed;
    public int Capacity => _capacity;
    public int Health => _health;

    public bool TryUpgradeHealth(int amount)
    {
        if (CanUpgrade(_health, amount, _maxHealth))
        {
            _health += amount;

            return true;
        }

        return false;
    }

    public bool TryUpgradeCapacity(int amount)
    {
        if (CanUpgrade(_capacity, amount, _maxCapacity))
        {
            _capacity += amount;

            return true;
        }

        return false;
    }

    public bool TryUpgradeSpeed(float amount)
    {
        if (CanUpgrade(_speed, amount, _maxSpeed))
        {
            _speed += amount;

            return true;
        }

        return false;
    }

    private bool CanUpgrade(float currentAmount, float increment, float maxAmount)
    {
        return currentAmount + increment <= maxAmount;
    }
}
