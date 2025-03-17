public class PlaneterySystemPresenter
{
    private readonly IPlaneterySystemView _view;
    private readonly PlaneterySystem _model;

    public PlaneterySystemPresenter(IPlaneterySystemView view, PlaneterySystem systemData, PlanetClickHandler clickHandler)
    {
        _view = view;
        _model = systemData;

        clickHandler.Clicked += OnPlanetClicked;

        Initialize();
    }

    private void OnPlanetClicked(string systemId)
    {
        SpaceBody planet = _model.SetPlanetById(systemId);
        _view.DisplayPlanetInfo(planet);
    }

    private void Initialize()
    {
        _view.DisplayStar();

        foreach (var planet in _model.Planets)
        {
            _view.DisplayPlanet(planet);
        }
    }
}
