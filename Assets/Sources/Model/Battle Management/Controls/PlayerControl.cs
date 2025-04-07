using System;
using UnityEngine;

public class PlayerControl
{
    private readonly Mover _mover;
    private readonly Shooter _shooter;
    private readonly Rotator _rotator;
    private readonly PlayerAnimator _animator;
    private readonly Interactor _interactor;

    public event Action Shot;
    public event Action Interacted;

    public PlayerControl(Mover mover, Rotator roatator, Shooter shooter, PlayerAnimator animator, Interactor interactor)
    {
        _mover = mover;
        _shooter = shooter;
        _rotator = roatator;
        _animator = animator;
        _interactor = interactor;

        _interactor.ActionButtonPressed += OnInteractorPressed;
        _shooter.Shot += OnShot;
    }

    ~PlayerControl()
    {
        _interactor.ActionButtonPressed -= OnInteractorPressed;
        _shooter.Shot -= OnShot;
    }

    public Vector3 GetMovement(float deltaTime, bool isGrounded, Quaternion rotation)
    {
        Vector3 movement = _mover.GetNextMovement(deltaTime, isGrounded);
        _animator.UpdateDirection(_mover.Direction, rotation);

        return movement;
    }

    public Quaternion GetRotation(Vector3 position)
    {
        Quaternion roatation = _rotator.GetRotation(position);

        return roatation;
    }

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        _shooter.Shoot(position, rotation);
    }

    private void OnInteractorPressed()
    {
        Interacted?.Invoke();
    }

    private void OnShot()
    {
        Shot?.Invoke();
    }
}
