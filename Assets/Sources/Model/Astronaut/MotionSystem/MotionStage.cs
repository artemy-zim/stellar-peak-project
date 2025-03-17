using UnityEngine;

[System.Serializable]
public struct MotionStage
{
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    [SerializeField] private Vector3 _startAngle;

    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private float _rotationSpeed;

    [SerializeField, Vector3Range(-1, 1)] private Vector3 _rotationDirection;

    public readonly Vector3 StartPoint => _startPoint;
    public readonly Vector3 EndPoint => _endPoint;
    public readonly Vector3 StartAngle => _startAngle;
    public readonly float MoveSpeed => _moveSpeed;
    public readonly float RotationSpeed => _rotationSpeed;
    public readonly Vector3 RotationDirection => _rotationDirection;
}
