public class AstronautCard
{
    private readonly AstronautInfo _info;
    private readonly AstronautStats _stats;

    public AstronautCard(AstronautInfo info, AstronautStats stats)
    {
        _info = info;

        _stats = stats;
    }

    public IReadOnlyAstronautInfo Info => _info;
    public IReadOnlyAstronautStats Stats => _stats;
    public IUpgradable Upgradable => _stats;

    public void Decease()
    {
        _info.ChangeState(AstronautStatus.Deceased);
    }
}

