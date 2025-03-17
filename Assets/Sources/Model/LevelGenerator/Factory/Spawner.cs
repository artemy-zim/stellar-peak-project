using System;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class Spawner<T> where T : MonoBehaviour, ISpawnable
{
    protected readonly GameObject _prefab;

    private Transform _container;

    protected Spawner(GameObject prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }

    public virtual T Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject instance = Object.Instantiate(_prefab, position, rotation, _container);

        if (instance.TryGetComponent(out T spawnable))
        {
            spawnable.OnSpawn();

            return spawnable;
        }

        throw new InvalidOperationException(nameof(spawnable));
    }
}
