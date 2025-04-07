using UnityEngine;

public class PlaneterySystemView : MonoBehaviour, IPlaneterySystemView
{
    [SerializeField] private Transform _systemRoot;
    [SerializeField] private float observationDistance;

    [SerializeField] private PlanetCardView _planetCard;

    public void DisplayPlanet(SpaceBody planetData)
    {
        var planet = Instantiate(planetData.Prefab, _systemRoot);
        planet.name = planetData.Name;

        planet.transform.localScale = Vector3.one * planetData.ScaleFactor;

        var angle = planetData.RevolutionAroundDegree * Mathf.Deg2Rad;
        var position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * planetData.CenterDistance;
        planet.transform.localPosition = position;

        if (planet.TryGetComponent(out PlanetView planetView))
            planetView.Initialize(planetData.ID, _systemRoot, observationDistance);
    }

    public void DisplayPlanetInfo(SpaceBody planetData)
    {
        _planetCard.Render(planetData);
    }

    public void DisplayStar(GameObject starPrefab)
    {
        Instantiate(starPrefab, _systemRoot);
    }
}
