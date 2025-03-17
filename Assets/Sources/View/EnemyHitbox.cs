using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField] private EnemyView _enemyView;

    public IDestroyable Destroyable => _enemyView;
}
