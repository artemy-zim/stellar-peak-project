using UnityEngine;

public class ResourceSpawner : Spawner<ResourceView>
{
    public ResourceSpawner(ResourceView prefab, Transform container) : base(prefab.gameObject, container) { }

    public ResourceView Spawn(Vector3 position)
    {
        return Spawn(position, Quaternion.identity);
    }
}
