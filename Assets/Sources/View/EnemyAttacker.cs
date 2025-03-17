using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Vector3 _hitForce;

    public UnityEvent _onPlayerKilled;

    public void TryAttackPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(_attackPoint.position, _attackRange, _playerLayer);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out PlayerView player))
            {
                player.Hit(_hitForce, hit.ClosestPoint(_attackPoint.position));

                break;
            }
        }
    }
}
