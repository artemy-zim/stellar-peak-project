using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class ResourcePresenter
{
    private readonly List<ResourceView> _views;
    private readonly Inventory _inventory;
    private readonly ResourceInfoPanel _resourcePanel;

    private ResourceView _currentInteractedResource;

    public event Action Interacted;
    public event Action Picked;

    public ResourcePresenter(ResourceSpawner spawner, List<SpawnPoint> spawnPoints, IReadOnlyList<IReadOnlyResource> resources, ResourceInfoPanel panel, Inventory inventory)
    {
        _views = new List<ResourceView>();
        _inventory = inventory;
        _resourcePanel = panel;

        _resourcePanel.Clicked += PickCurrentResource;

        InitViews(spawner, resources, spawnPoints);
    }

    ~ResourcePresenter()
    {
        foreach (ResourceView view in _views)
            view.Interacted -= HandleInteraction;

        _resourcePanel.Clicked -= PickCurrentResource;
    }

    private void InitViews(ResourceSpawner spawner, IReadOnlyList<IReadOnlyResource> resources, List<SpawnPoint> spawnPoints)
    {
        List<SpawnPoint> _takenSpawnPoints = new();

        foreach (IReadOnlyResource resource in resources)
        {
            List<SpawnPoint> freeSpawnPoints = spawnPoints.Except(_takenSpawnPoints).ToList();
            ResourceView view = spawner.Spawn(freeSpawnPoints[Random.Range(0, _takenSpawnPoints.Count)].GetPosition());

            view.Init(resource.Mesh, resource.Materials, resource.ID);
            view.Interacted += HandleInteraction;

            _views.Add(view);
        }
    }

    private void PickCurrentResource()
    {
        _currentInteractedResource.Destroy();
        Picked?.Invoke();
        _inventory.TryAdd(_currentInteractedResource.ID);
    }

    private void HandleInteraction(string id)
    {
        IReadOnlyResource resource =  GameSession.Instance.SpaceBody.Resources.FirstOrDefault(resource => resource.ID == id);

        if (resource == null)
            return;

        _currentInteractedResource = _views.FirstOrDefault(resource => resource.ID.Equals(id));
        _resourcePanel.UpdateView(resource.Sprite, resource.Name);

        Interacted?.Invoke();
    }
}
