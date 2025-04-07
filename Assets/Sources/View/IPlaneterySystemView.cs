using UnityEngine;

public interface IPlaneterySystemView
{
    public void DisplayStar(GameObject starPrefab);
    public void DisplayPlanet(SpaceBody planetData);
    public void DisplayPlanetInfo(SpaceBody planetData);
}
