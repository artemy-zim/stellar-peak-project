using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private TextMeshProUGUI _collectedResourcesAmount;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;

    public event Action PauseButtonClicked;
    public event Action ResumeButtonClicked;

    private int _maxResources;

    public void Init(int maxResources)
    {
        _maxResources = Mathf.Clamp(maxResources, 1, int.MaxValue);
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(() => PauseButtonClicked?.Invoke());
        _resumeButton.onClick.AddListener(() => ResumeButtonClicked?.Invoke());
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(() => PauseButtonClicked?.Invoke());
        _pauseButton.onClick.RemoveListener(() => ResumeButtonClicked?.Invoke());
    }

    public void UpdateTime(int minutes, int seconds)
    {
        _timer.text = $"{minutes:D2}:{seconds:D2}";
    }

    public void UpdateCollectedResources(int resourcesAmount)
    {
        _collectedResourcesAmount.text = $"{resourcesAmount}/{_maxResources}"; 
    }
}
