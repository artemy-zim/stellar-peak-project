using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter
{
    private readonly ProjectileSpawner _spawner;
    private readonly PlayerInput _input;
    private readonly float _fireRate;
    private float _lastShotTime;

    private CompositeDisposable _disposables;

    public event Action Shot;

    public Shooter(float fireRate, PlayerInput playerInput, ProjectileSpawner spawner)
    {
        _input = playerInput;
        _fireRate = fireRate;
        _lastShotTime = -fireRate;
        _spawner = spawner;
        _disposables = new CompositeDisposable();

        _input.Player.Shoot.performed += OnInput;
    }

    ~Shooter()
    {
        _disposables.Dispose();
        _input.Player.Shoot.performed -= OnInput;
    }

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        Blast projectile = _spawner.Spawn(position, rotation);

        projectile.OnHit
            .Take(1)
            .Subscribe(_ => _spawner.ReturnToPool(projectile))
            .AddTo(_disposables);
    }

    private bool CanShoot()
    {
        return Time.time >= _lastShotTime + _fireRate;
    }

    private void OnInput(InputAction.CallbackContext _)
    {
        if (CanShoot())
        {
            _lastShotTime = Time.time;

            Shot?.Invoke();
        }
    }
}
