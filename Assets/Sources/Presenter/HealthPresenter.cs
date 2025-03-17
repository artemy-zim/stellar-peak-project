public class HealthPresenter
{
    private readonly IDestroyable _destroyable;
    private readonly Health _health;

    public HealthPresenter(IDestroyable view, Health health)
    {
        _destroyable = view;
        _health = health;

        _health.Ended += Die;
        _destroyable.Damaged += TakeDamage;
    }

    ~HealthPresenter()
    {
        _health.Ended -= Die;
        _destroyable.Damaged -= TakeDamage;
    }

    public void TakeDamage()
    {
        _health.TakeDamage();
    }

    private void Die()
    {
        _destroyable.Destroy();
    }
}
