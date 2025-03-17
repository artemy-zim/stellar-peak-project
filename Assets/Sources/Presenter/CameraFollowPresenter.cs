using UnityEngine;

public class CameraFollowPresenter
{
    private readonly CameraFollower _cameraFollower;
    private readonly CameraView _view;
    private readonly Transform _target;

    public CameraFollowPresenter(CameraFollower cameraFollower, CameraView view, Transform target)
    {
        _cameraFollower = cameraFollower;
        _view = view;
        _target = target;

        _view.Init(_cameraFollower.GetPosition(_target.position));
    }

    public void Update()
    {
        Vector3 smoothedPosition = _cameraFollower.GetSmoothedPosition(_view.transform.position, _target.position);
        _view.SetPosition(smoothedPosition);
    }
}
