using AYellowpaper;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlaneterySystemInitializer : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IPlaneterySystemView> _planeterySystemView;
    [SerializeField] private List<AstronautCardListView> _astronautCardListView;
    [SerializeField] private PlanetClickHandler _clickHandler;
    [SerializeField] private PlaneterySystemHeaderView _headerView;
    [SerializeField] private AstronautFileView _fileView;
    [SerializeField] private ResourceCellListView _cellListView;

    [Header("Upgrade")]
    [SerializeField] private AstronautUpgradeView _upgradeView;
    [SerializeField] private int _healthCost;
    [SerializeField] private int _healthIncrement;
    [SerializeField] private int _speedCost;
    [SerializeField] private float _speedIncrement;
    [SerializeField] private int _capacityIncrement;
    [SerializeField] private int _capacityCost;

    private void Start()
    {
        PlaneterySystem systemData = GameSession.Instance.SelectedSystem;
        new PlaneterySystemPresenter(_planeterySystemView.Value, systemData, _clickHandler);
        new AstronautLoaderPresenter(_astronautCardListView);
        new ResourceLoaderPresenter(_cellListView);

        new AstronautUpgradePresenter(
            new AstronautUpgrader(
                new UpgradeRules(_healthIncrement, _healthCost, _speedIncrement, _speedCost, _capacityIncrement, _capacityCost), 
                GameSession.Instance.Storage),
            _upgradeView,
            _headerView,
            _fileView);
    }
}
