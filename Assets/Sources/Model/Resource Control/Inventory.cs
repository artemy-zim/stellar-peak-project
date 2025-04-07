using System.Collections.Generic;
using System.Linq;
using UniRx;

public class Inventory
{
    private readonly ReactiveCollection<IReadOnlyResource> _resources;
    private readonly ReactiveProperty<int> _resourcesCount;
    private readonly int _capacity;

    private readonly CompositeDisposable _disposables;

    public Inventory(int capacity)
    {
        _capacity = capacity;
        _resources = new ReactiveCollection<IReadOnlyResource>();
        _resourcesCount = new ReactiveProperty<int>(_resources.Count);
        _disposables = new CompositeDisposable(); 

        _resources.ObserveAdd()   
            .Subscribe(_ => _resourcesCount.Value = _resources.Count)  
            .AddTo(_disposables);
    }

    ~Inventory()
    {
        _disposables.Dispose();
    }

    public IReadOnlyReactiveProperty<int> ResourcesCount => _resourcesCount;
    public IEnumerable<IReadOnlyResource> CollectedResources => _resources;

    public void TryAdd(string id)
    {
        if (_resources.Count >= _capacity)
            return;

        IReadOnlyList<IReadOnlyResource> resources = GameSession.Instance.SpaceBody.Resources;
        IReadOnlyResource resource = resources.FirstOrDefault(resource => resource.ID.Equals(id));

        if (resource != null)
            _resources.Add(resource);
    }
}
