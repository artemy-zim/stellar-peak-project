using System;
using UnityEngine;

public class Health
{
    private readonly int _minHealth;
    private int _currentHealth;

    public event Action Ended;

    public Health(int maxHealth)
    {
        _currentHealth = maxHealth;
        _minHealth = 0;
    }

    public void TakeDamage()
    {
        _currentHealth--;
        _currentHealth = Mathf.Max(_minHealth, _currentHealth);

        if(_currentHealth <= _minHealth)
            Ended?.Invoke();
    }
}
