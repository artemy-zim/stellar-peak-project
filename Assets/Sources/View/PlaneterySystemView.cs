using UnityEngine;

public class PlaneterySystemView : MonoBehaviour, IPlaneterySystemView
{
    [SerializeField] private PlanetView _planetPrefab; 
    [SerializeField] private GameObject _starPrefab;   
    [SerializeField] private Transform _systemRoot;

    [SerializeField] private PlanetCardView _planetCard;

    public void DisplayPlanet(SpaceBody planetData)
    {
        var planet = Instantiate(_planetPrefab, _systemRoot);
        planet.name = planetData.Name;

        planet.transform.localScale = Vector3.one * planetData.ScaleFactor;

        var angle = planetData.RevolutionAroundDegree * Mathf.Deg2Rad;
        var position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * planetData.CenterDistance;
        planet.transform.localPosition = position;

        if (planet.TryGetComponent(out PlanetView planetView))
            planetView.Initialize(planetData.ID);
    }

    public void DisplayPlanetInfo(SpaceBody planetData)
    {
        _planetCard.Render(planetData);
    }

    public void DisplayStar()
    {
        var star = Instantiate(_starPrefab, _systemRoot);
    }
}
