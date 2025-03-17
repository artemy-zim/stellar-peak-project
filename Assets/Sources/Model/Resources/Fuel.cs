using System;

public class Fuel : IReadOnlyFuel
{
    private readonly int _maxAmount;
    private int _amount;

    public event Action<int, int> Changed;
    public bool IsEnough => _amount > 0;

    public Fuel(int amount, int maxAmount)
    {
        Validate(ref amount, maxAmount);

        _amount = amount;
        _maxAmount = maxAmount;

        NotifyFuelChanged();
    }

    public void Fill()
    {
        if (_amount >= _maxAmount)
            return;

        _amount++;
        NotifyFuelChanged();
    }

    public void Spend()
    {
        if (_amount <= 0)
            return;

        _amount--;
        NotifyFuelChanged();
    }

    private void Validate(ref int amount, int maxAmount)
    {
        if(amount > maxAmount)
            amount = maxAmount;
    }

    private void NotifyFuelChanged()
    {
        Changed?.Invoke(_amount, _maxAmount);
    }
}
