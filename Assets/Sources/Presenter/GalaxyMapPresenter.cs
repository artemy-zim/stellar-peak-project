using UnityEngine;

public class GalaxyMapPresenter
{
    private readonly GalaxyMapView _view;
    private readonly FuelView _fuelView;
    private readonly GalaxyMap _model;
    private readonly PlanetarySystemGenerator _generator;

    public GalaxyMapPresenter(GalaxyMapView view, GalaxyMap model, PlanetarySystemGenerator generator, FuelView fuelView)
    {
        _view = view;
        _model = model;
        _generator = generator;
        _fuelView = fuelView;

        _model.Fuel.Changed += _fuelView.UpdateView;
        _view.SystemSelected += OnSystemSelected;
        _fuelView = fuelView;
    }

    public void GenerateGalaxy(int nodeCount, Vector2 canvasSize, int rows, int columns)
    {
        float cellWidth = canvasSize.x / columns;
        float cellHeight = canvasSize.y / rows;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                PlaneterySystem system = GenerateNode(cellWidth, cellHeight, row, col, canvasSize);
                _model.AddSystem(system);

                nodeCount--;
            }

            if (nodeCount <= 0)
                break;
        }

        _model.GenerateConnections();
        _view.Initialize(_model.Connections);

        SetRandomStartSystem();
    }

    public void SetRandomStartSystem()
    {
        string startSystemID = _model.GetRandomSystemId();
        _model.SetCurrentSystem(startSystemID);
        _view.SetPlayerSystem(startSystemID);
    }

    private void OnSystemSelected(string systemId)
    {
        if (_model.IsCurrentSystem(systemId))
            _view.ShowSystemInfo(_model.GetSystemById(systemId));
        else
            TravelToSystem(systemId);
    }

    private void TravelToSystem(string systemId)
    {
        if (_model.CanTravelTo(systemId))
        {
            _model.SetCurrentSystem(systemId);
            _view.SetPlayerSystem(systemId);
        }
    }

    private PlaneterySystem GenerateNode(float cellWidth, float cellHeight, int row, int col, Vector2 canvasSize)
    {
        float x = Random.Range(col * cellWidth, (col + 1) * cellWidth) - canvasSize.x / 2;
        float y = Random.Range(row * cellHeight, (row + 1) * cellHeight) - canvasSize.y / 2;

        PlaneterySystem systemModel = _generator.GenerateSystemModel();
        _view.AddNode(new Vector3(x, y, 0), systemModel);

        return systemModel;
    }
}
