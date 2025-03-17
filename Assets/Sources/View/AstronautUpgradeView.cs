using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class AstronautUpgradeView : MonoBehaviour
{
    [SerializeField] private Button _upgradeHealthButton;
    [SerializeField] private Button _upgradeSpeedButton;
    [SerializeField] private Button _upgradeCapacityButton;

    public IObservable<Unit> HealthClicked => _healthClicked;
    public IObservable<Unit> SpeedClicked => _speedClicked;
    public IObservable<Unit> CapacityClicked => _capacityClicked;

    private readonly Subject<Unit> _healthClicked = new();
    private readonly Subject<Unit> _speedClicked = new();
    private readonly Subject<Unit> _capacityClicked = new();

    private void OnEnable()
    {
        _upgradeHealthButton.onClick.AddListener(() => _healthClicked.OnNext(Unit.Default));
        _upgradeCapacityButton.onClick.AddListener(() => _capacityClicked.OnNext(Unit.Default));
        _upgradeSpeedButton.onClick.AddListener(() => _speedClicked.OnNext(Unit.Default));
    }

    private void OnDisable()
    {
        _upgradeHealthButton.onClick.RemoveAllListeners();
        _upgradeCapacityButton.onClick.RemoveAllListeners();
        _upgradeSpeedButton.onClick.RemoveAllListeners();
    }

    private void OnDestroy()
    {
        _healthClicked.Dispose();
        _speedClicked.Dispose();
        _capacityClicked.Dispose();
    }

    public void Log(string text)
    {
        Debug.Log(text);
    }
}
