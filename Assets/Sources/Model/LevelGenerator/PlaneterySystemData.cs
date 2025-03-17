using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaneterySystemData", menuName = "Game/PlaneterySystemData")]
public class PlaneterySystemData : ScriptableObject
{
    [SerializeField] private List<string> _names;
    [SerializeField] private List<string> _descriptions;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private int _minPlanetsCount;
    [SerializeField] private int _maxPlanetsCount;

    public IReadOnlyList<string> Names => _names;
    public IReadOnlyList<string> Descriptions => _descriptions;
    public IReadOnlyList<Sprite> Sprites => _sprites;
    public int MaxPlanetsCount => _maxPlanetsCount;
    public int MinPlanetsCount => _minPlanetsCount;
}
