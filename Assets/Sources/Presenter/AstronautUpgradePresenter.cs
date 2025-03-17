using System;
using System.Diagnostics;
using UniRx;

public class AstronautUpgradePresenter
{
    private readonly AstronautUpgrader _upgrader;
    private readonly AstronautUpgradeView _upgradeView;
    private readonly AstronautFileView _fileView;
    private readonly PlaneterySystemHeaderView _headerView;

    private readonly CompositeDisposable _disposables = new();

    public AstronautUpgradePresenter(AstronautUpgrader upgrader, AstronautUpgradeView upgradeView, PlaneterySystemHeaderView headerView, AstronautFileView fileView)
    {
        _upgrader = upgrader;
        _upgradeView = upgradeView;
        _fileView = fileView;
        _headerView = headerView;

        _upgradeView.HealthClicked.Subscribe(_ => TryUpgrade(_upgrader.TryUpgradeHealth)).AddTo(_disposables);
        _upgradeView.SpeedClicked.Subscribe(_ => TryUpgrade(_upgrader.TryUpgradeSpeed)).AddTo(_disposables);
        _upgradeView.CapacityClicked.Subscribe(_ => TryUpgrade(_upgrader.TryUpgradeCapacity)).AddTo(_disposables);
    }

    private void TryUpgrade(Func<IUpgradable, bool> upgradeAction)
    {
        AstronautCard card = GameSession.Instance.ChosenAstronaut;

        if (upgradeAction.Invoke(card.Upgradable))
        {

            _fileView.Render(card);
            _headerView.UpdateView();
        }
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
