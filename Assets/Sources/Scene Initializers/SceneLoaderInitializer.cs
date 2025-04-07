using UnityEngine;

public class SceneLoaderInitializer : MonoBehaviour
{
    [SerializeField] private LoadingScreen loadingScreenView;

    private LoadingScreenPresenter _presenter;

    private void Awake()
    {
        var model = new SceneLoader();
        _presenter = new LoadingScreenPresenter(loadingScreenView, model);
    }

    public void StartLoadingScene(string sceneName)
    {
        _presenter.LoadScene(sceneName);
    }
}
