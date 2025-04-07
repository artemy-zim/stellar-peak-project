using System.Collections.Generic;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour, ISpawnable
{
    private readonly Queue<T> _pool = new();
    private readonly GameObject _prefab;
    private readonly Transform _parent;

    public ObjectPool(GameObject prefab, Transform parent = null, int initialSize = 10)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = CreateNewObject();
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    private T CreateNewObject()
    {
        GameObject instance = Object.Instantiate(_prefab, _parent);

        if (instance.TryGetComponent(out T obj))
            return obj;

        throw new InvalidOperationException(nameof(obj));
    }

    public T Get(Vector3 position, Quaternion rotation)
    {
        T obj;

        if (_pool.Count > 0)
        {
            obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = CreateNewObject();
        }

        obj.transform.SetPositionAndRotation(position, rotation);
        obj.OnSpawn();

        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}
