using System;
using UnityEngine;
using UnityEngine.AI;
using Worq.AEAI.Enemy;

public class EnemyView : MonoBehaviour, IDestroyable, ISpawnable
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private EnemyAI _ai;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _ragdollRigidbodies;

    private Vector3 _selfHitForce;
    private Vector3 _selfHitPoint;

    public event Action Damaged;

    public void OnSpawn()
    {
        DisableDeathState();
    }

    public void Hit(Vector3 hitForce, Vector3 hitPoint)
    {
        _selfHitForce = hitForce;
        _selfHitPoint = hitPoint;
        _ai.isSeeking = true;

        Damaged?.Invoke();
    }

    public void Destroy()
    {
        EnableDeathState();

        foreach (var rb in _ragdollRigidbodies)
            rb.AddForceAtPosition(_selfHitForce, _selfHitPoint, ForceMode.Impulse);
    }

    private void EnableDeathState()
    {
        _navMeshAgent.isStopped = true;
        _ai.enabled = false;
        _animator.enabled = false;

        foreach (Rigidbody rb in _ragdollRigidbodies)
            rb.isKinematic = false;
    }

    private void DisableDeathState()
    {
        _navMeshAgent.isStopped = false;
        _ai.enabled = true;
        _animator.enabled = true;

        foreach (Rigidbody rb in _ragdollRigidbodies)
            rb.isKinematic = true;
    }
}
