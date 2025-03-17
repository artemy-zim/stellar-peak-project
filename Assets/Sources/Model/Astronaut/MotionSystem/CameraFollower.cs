using UnityEngine;

public class CameraFollower
{
    private readonly Vector3 _offset;
    private readonly float _smoothTime;

    private Vector3 _currentVelocity;

    public CameraFollower(Vector3 offset, float smoothTime)
    {
        _offset = offset;
        _smoothTime = smoothTime;
        _currentVelocity = Vector3.zero;
    }

    public Vector3 GetPosition(Vector3 targetPosition)
    {
        return _offset + targetPosition;
    }

    public Vector3 GetSmoothedPosition(Vector3 currentCameraPosition, Vector3 targetPosition)
    {
        Vector3 targetCameraPosition = targetPosition + _offset;
        return Vector3.SmoothDamp(currentCameraPosition, targetCameraPosition, ref _currentVelocity, _smoothTime);
    }
}
