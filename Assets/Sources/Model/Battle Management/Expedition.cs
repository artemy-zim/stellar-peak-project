using System;
using UniRx;

public class Expedition
{
    private readonly Inventory _inventory;
    private readonly Timer _timer;
    private readonly PauseHandler _pauseHandler;
    private readonly CompositeDisposable _disposables;

    public event Action<int, int> TimeChanged;
    public event Action<int> ResourcesCountChanged;

    public Expedition(Timer timer, Inventory inventory, PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
        _disposables = new();
        _timer = timer;
        _inventory = inventory;

        SubscribeTime(_timer);
        SubscribeInventory(_inventory);
    }

    ~Expedition()
    {
        _disposables.Dispose();
    }

    public void Stop()
    {
        _pauseHandler.Pause();
    }

    public void Resume()
    {
        _pauseHandler.Resume();
    }

    private void SubscribeInventory(Inventory inventory)
    {
        inventory.ResourcesCount
            .Subscribe(count => ResourcesCountChanged?.Invoke(count))
            .AddTo(_disposables);
    }

    private void SubscribeTime(Timer timer)
    {
        timer.TimeRemaining
            .Subscribe(time => TimeChanged?.Invoke(time.minutes, time.seconds))
            .AddTo(_disposables);

        timer.StartTimer();
    }
}
