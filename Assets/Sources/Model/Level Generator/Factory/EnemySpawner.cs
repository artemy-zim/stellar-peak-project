using UnityEngine;

public class EnemySpawner : Spawner<EnemyView>
{
    public EnemySpawner(EnemyView prefab, Transform container) : base(prefab.gameObject, container) { }

    public override EnemyView Spawn(Vector3 position, Quaternion rotation)
    {
        return base.Spawn(position, rotation);
    }
}
