public class LoadingScreenPresenter
{
    private readonly LoadingScreen _view;
    private readonly SceneLoader _model;

    public LoadingScreenPresenter(LoadingScreen view, SceneLoader model)
    {
        _view = view;
        _model = model;
    }

    public async void LoadScene(string sceneName)
    {
        _view.StartAnimation();

        await _model.LoadSceneAsync(sceneName, progress => _view.UpdateProgress(progress));
    }
}
