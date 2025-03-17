using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CameraMotionPresenter
{
    private readonly MotionCameraView _camera;
    private readonly MotionRepository _motion;

    private MotionStage _currentStage;

    public CameraMotionPresenter(MotionCameraView camera, MotionRepository motion)
    {
        Validate(camera, motion);

        _camera = camera;
        _motion = motion;

        InitStage();
    }

    public void Update(float deltaTime)
    {
        if(Vector3.Distance(_camera.GetPosition(), _currentStage.EndPoint) < 0.1f)
            InitStage();

        Vector3 newPosition = Vector3.MoveTowards(_camera.GetPosition(), _currentStage.EndPoint, _currentStage.MoveSpeed * deltaTime);
        Vector3 newRotation = _currentStage.RotationSpeed * deltaTime * _currentStage.RotationDirection;

        _camera.Move(newPosition);
        _camera.Rotate(newRotation);
    }

    private void InitStage()
    {
        _currentStage = _motion.GetNextStage();

        _camera.Move(_currentStage.StartPoint);
        _camera.SetAngle(_currentStage.StartAngle);
    }

    private void Validate(MotionCameraView camera, MotionRepository motion)
    {
        try
        {
            ValidationExtensions.ValidateIfNull(camera);
            ValidationExtensions.ValidateIfNull(motion);
        }
        catch (ArgumentNullException ex)
        {
            string message = $"{ex.Message} can not be null in {GetType().Name}";

            Debug.LogError(message);
            throw ex;
        }
    }
}
