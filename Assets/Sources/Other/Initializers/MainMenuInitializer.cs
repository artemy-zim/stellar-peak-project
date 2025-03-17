using System.Collections.Generic;
using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
    [SerializeField] private MotionCameraView _cameraView;
    [SerializeField] private List<MotionStage> _motionStages;

    private CameraMotionPresenter _presenter;

    private void Awake()
    {
        MotionRepository motionRepository = new(_motionStages);
        _presenter = new(_cameraView, motionRepository);
    }

    private void Update()
    {
        _presenter.Update(Time.deltaTime);
    }
}
