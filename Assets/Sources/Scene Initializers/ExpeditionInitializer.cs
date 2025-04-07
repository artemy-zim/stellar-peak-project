using AYellowpaper;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionInitializer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private List<SpawnPoint> _playerSpawnPoints;
    [SerializeField] private InterfaceReference<IDestroyable, PlayerView> _playerDestroyable;
    [SerializeField] private PlayerView _playerView;

    [Header("Enemy")]
    [SerializeField] private List<SpawnPoint> _enemySpawnPoints;
    [SerializeField] private EnemyView _enemy;
    [SerializeField, Min(0)] private int _enemyHealthAmount;
    [SerializeField] private Transform _enemyContainer;

    [Header("Panel")]
    [SerializeField] private ExpeditionView _expeditionView;
    [SerializeField] private int _durationSeconds;

    [Header("Camera")]
    [SerializeField] private CameraView _cameraView;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField, Min(0)] private float _cameraSmoothTime;

    [Header("Resources")]
    [SerializeField] private List<SpawnPoint> _resourceSpawnPoints;
    [SerializeField] private ResourceView _resourcePrefab;
    [SerializeField] private Transform _resourceContainer;
    [SerializeField] private ResourceInfoPanel _resourcePanel;
    [SerializeField] private ExpeditionFinalizer _expeditionFinalizer;

    private CameraFollowPresenter _cameraPresenter;
    private ExpeditionPresenter _expeditionPresenter;
    private ResourcePresenter _resourcePresenter;
    private Timer _timer;

    private void Awake()
    {
        IReadOnlyList<IReadOnlyResource> resources = GameSession.Instance.SpaceBody.Resources;
        int resourcesCount = resources.Count;

        Inventory inventory = new(GameSession.Instance.ChosenAstronaut.Stats.Capacity);
        _timer = new(_durationSeconds);

        InitEnemies();
        InitPlayer();
        InitResources(inventory, resources);
        InitExpeditionInfo(resourcesCount, inventory);
    }

    private void LateUpdate()
    {
        _cameraPresenter.Update();
    }

    private void InitExpeditionInfo(int resourcesCount, Inventory inventory)
    {
        _expeditionFinalizer.Init(inventory);
        _timer.Completed += _expeditionFinalizer.ProcessSuccess;
        _expeditionView.Init(resourcesCount);

        _expeditionPresenter = new ExpeditionPresenter(
            _resourcePresenter,
            new Expedition(
            _timer,
            inventory,
            new PauseHandler()),
            _expeditionView);
    }

    private void InitResources(Inventory inventory, IReadOnlyList<IReadOnlyResource> resources)
    {
        _resourcePresenter = new ResourcePresenter(
            new ResourceSpawner(_resourcePrefab, _resourceContainer),
            _resourceSpawnPoints,
            resources,
            _resourcePanel,
            inventory);
    }

    private void InitPlayer()
    {
        int playerHealth = GameSession.Instance.ChosenAstronaut.Stats.Health;
        new HealthPresenter(_playerDestroyable.Value, new Health(playerHealth));

        _playerView.transform.position = _playerSpawnPoints[Random.Range(0, _playerSpawnPoints.Count)].GetPosition();
        _cameraPresenter = new CameraFollowPresenter(new CameraFollower(_cameraOffset, _cameraSmoothTime), _cameraView, _playerView.transform);
    }

    private void InitEnemies()
    {
        int enemyCount = GameSession.Instance.SpaceBody.EnemyCount;
        new HealthPresenter(_enemy, new Health(_enemyHealthAmount));

        EnemySpawner enemySpawner = new(_enemy, _enemyContainer);

        for (int i = 0; i < enemyCount - 1; i++)
        {
            IDestroyable enemyDestroyable = enemySpawner.Spawn(_enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Count)].GetPosition(), Quaternion.identity);
            new HealthPresenter(enemyDestroyable, new Health(_enemyHealthAmount));
        }
    }

    private void OnDestroy()
    {
        _timer.Completed -= _expeditionFinalizer.ProcessSuccess;
        _expeditionPresenter.Dispose();
    }
}
