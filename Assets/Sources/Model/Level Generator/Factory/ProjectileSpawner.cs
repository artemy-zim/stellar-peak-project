using UnityEngine;

public class ProjectileSpawner : Spawner<Blast>
{
    private readonly ObjectPool<Blast> _pool;

    public ProjectileSpawner(Blast prefab, int initialPoolSize, Transform container) : base(prefab.gameObject, container)
    {
        _pool = new ObjectPool<Blast>(prefab.gameObject, container, initialPoolSize);
    }

    public override Blast Spawn(Vector3 position, Quaternion rotation)
    {
        return _pool.Get(position, rotation);
    }

    public void ReturnToPool(Blast projectile)
    {
        _pool.Return(projectile);
    }
}
