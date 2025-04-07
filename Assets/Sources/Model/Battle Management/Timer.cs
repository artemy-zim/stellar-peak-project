using System;
using UniRx;
using UnityEngine;

public class Timer
{
    private readonly ReactiveProperty<(int minutes, int seconds)> _timeRemaining = new((0, 0));
    private readonly int _initialTime;
    private float _timeLeft;

    private bool _isRunning;

    private IDisposable _timerDisposable;

    public event Action Completed;

    public Timer(int duration)
    {
        _initialTime = duration;
        _timeLeft = duration;
    }

    public IReadOnlyReactiveProperty<(int minutes, int seconds)> TimeRemaining => _timeRemaining;

    public void StartTimer()
    {
        if (_isRunning) return;

        _isRunning = true;
        _timeLeft = _initialTime;

        _timerDisposable = Observable.Interval(TimeSpan.FromSeconds(1))
            .Where(_ => _isRunning)
            .Subscribe(_ =>
            {
                _timeLeft -= 1;
                if (_timeLeft <= 0)
                {
                    _timeLeft = 0;
                    _isRunning = false;
                    Completed?.Invoke();
                }
                UpdateTimeRemaining();
            });

        UpdateTimeRemaining();
    }

    public void StopTimer()
    {
        _isRunning = false;
        _timerDisposable?.Dispose();
    }

    private void UpdateTimeRemaining()
    {
        int minutes = Mathf.FloorToInt(_timeLeft / 60);
        int seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timeRemaining.SetValueAndForceNotify((minutes, seconds));
    }

    ~Timer()
    {
        _timerDisposable?.Dispose();
    }
}
