public class ExpeditionPresenter
{
    private readonly ExpeditionView _view;
    private readonly Expedition _expedition;
    private readonly ResourcePresenter _resourcePresenter;

    public ExpeditionPresenter(ResourcePresenter resourcePresenter, Expedition expedition, ExpeditionView view)
    {
        _expedition = expedition;
        _view = view;
        _resourcePresenter = resourcePresenter;

        _resourcePresenter.Interacted += _expedition.Stop;
        _resourcePresenter.Picked += _expedition.Resume;

        _expedition.TimeChanged += _view.UpdateTime;
        _expedition.ResourcesCountChanged += _view.UpdateCollectedResources;
        _view.PauseButtonClicked += _expedition.Stop;
        _view.ResumeButtonClicked += _expedition.Resume;
    }

    public void Dispose()
    {
        _expedition.TimeChanged -= _view.UpdateTime;
        _expedition.ResourcesCountChanged -= _view.UpdateCollectedResources;
        _view.PauseButtonClicked -= _expedition.Stop;
        _view.ResumeButtonClicked -= _expedition.Resume;
    }
}
