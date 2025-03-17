using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceBodyData", menuName = "Game/SpaceBodyData")]
public class SpaceBodyData : ScriptableObject
{
    [SerializeField] private List<string> _names;
    [SerializeField] private List<string> _descriptions;
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private int _minResourceCount;
    [SerializeField] private int _maxResourceCount;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _maxScaleFactor;
    [SerializeField] private float _minScaleFactor;

    public IReadOnlyList<string> Names => _names;
    public IReadOnlyList<string> Descriptions => _descriptions;
    public int MaxEnemyCount => _maxEnemyCount;
    public int MinResourceCount => _minResourceCount;
    public int MaxResourceCount => _maxResourceCount;
    public float MinDistance => _minDistance;
    public float MaxDistance => _maxDistance;
    public float MaxScaleFactor => _maxScaleFactor;
    public float MinScaleFactor => _minScaleFactor;
}
