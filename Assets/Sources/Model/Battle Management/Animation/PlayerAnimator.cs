using UniRx;
using UnityEngine;

public class PlayerAnimator
{
    private readonly ReactiveProperty<Vector2> _animationDirection = new(Vector2.zero);
    public IReadOnlyReactiveProperty<Vector2> AnimationDirection => _animationDirection;

    public void UpdateDirection(Vector3 movementDirection, Quaternion rotation)
    {
        Vector3 localDirection = Quaternion.Inverse(rotation) * movementDirection;
        Vector2 newDirection = new(localDirection.x, localDirection.z);

        _animationDirection.Value = newDirection;
    }
}
