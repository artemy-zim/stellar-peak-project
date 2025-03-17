using UnityEngine;

public class ControlInitializer : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField, Min(0)] private float _fireRate;
    [SerializeField] private Blast _projectilePrefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private Transform _container;

    [Header("Motion")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private PlayerControlView _playerControlView;
    [SerializeField] private PlayerAnimatorView _playerAnimatorView;
    [SerializeField] private float _gravity;
    [SerializeField] private float _groundSnap;
    [SerializeField] private LayerMask _groundLayer;

    private PlayerControlPresenter _controlPresenter;
    private PlayerInput _input;

    private void Awake()
    {
        InitControl();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    private void Update()
    {
        _controlPresenter.Update(Time.deltaTime);
    }

    private void InitControl()
    {
        float speed = GameSession.Instance.ChosenAstronaut.Stats.Speed;

        _input = new PlayerInput();
        PlayerAnimator playerAnimator = new();

        _controlPresenter = new PlayerControlPresenter(_playerControlView, new PlayerControl(
            new Mover(speed, _gravity, _groundSnap, _input),
            new Rotator(_mainCamera, _groundLayer),
            new Shooter(_fireRate, _input, new ProjectileSpawner(_projectilePrefab, _poolSize, _container)),
            playerAnimator,
            new Interactor(_input)));

        new PlayerAnimatorPresenter(playerAnimator, _playerAnimatorView);
    }
}
