using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blast : MonoBehaviour, ISpawnable
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private ParticleSystem _hitVFXPrefab;
    [SerializeField, Min(0)] private float _lifeTime;
    [SerializeField, Min(0)] private int _hitForceModifier;
    [SerializeField, Min(0)] private int _speed;

    private readonly Subject<Unit> _onHit = new();
    private IDisposable _movementSubscription;
    private Transform _transform;

    public IObservable<Unit> OnHit => _onHit;

    private void Awake()
    {
        _transform = transform;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.ValidateIfNull();
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
    }

    public void OnSpawn()
    {
        _movementSubscription?.Dispose();

        _movementSubscription = Observable.EveryUpdate()
            .Subscribe(_ => Move())
            .AddTo(this);

        Observable.Timer(TimeSpan.FromSeconds(_lifeTime))
            .Subscribe(_ => _onHit.OnNext(Unit.Default))
            .AddTo(this);
    }

    private void Move()
    {
        _transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerLayer) != 0)
            return;

        if (other.TryGetComponent(out EnemyHitbox enemyHitbox))
        {
            Vector3 hitForce = transform.forward * _hitForceModifier; 
            Vector3 hitPoint = other.ClosestPoint(transform.position);

            enemyHitbox.Destroyable.Hit(hitForce, hitPoint);
        }

        PlayHitEffect(other);
        _onHit.OnNext(Unit.Default);
    }

    private void PlayHitEffect(Collider other)
    {
        if (_hitVFXPrefab == null) 
            return;

        Vector3 point = other.ClosestPoint(_transform.position);
        Vector3 normal = (point - other.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(normal);

        ParticleSystem vfx = Instantiate(_hitVFXPrefab, point, rotation);
        vfx.Play();
        Destroy(vfx, vfx.main.duration);
    }
}
