using UnityEngine;

public class GalaxyMapInitializer : MonoBehaviour
{
    [SerializeField] private GalaxyMapView _galaxyMapView;
    [SerializeField] private PlanetarySystemGenerator _planetarySystemGenerator;
    [SerializeField] private FuelView _fuelView;

    [SerializeField] private int _nodeCount;
    [SerializeField] private Vector2 _canvasSize;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;

    [SerializeField] private int _maxFuel;

    private void Awake()
    {
        GalaxyMapPresenter presenter = new(_galaxyMapView, new GalaxyMap(new Fuel(_maxFuel, _maxFuel)), _planetarySystemGenerator, _fuelView);
        presenter.GenerateGalaxy(_nodeCount, _canvasSize, _rows, _columns);
    }
}
