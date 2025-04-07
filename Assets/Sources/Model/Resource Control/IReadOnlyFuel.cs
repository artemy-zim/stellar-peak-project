using System;

public interface IReadOnlyFuel
{
    public event Action<int, int> Changed;
}
