using System;
using System.Collections.Generic;

public class SpaceBody
{
    private readonly List<Resource> _resources;

    public SpaceBody(PlanetView prefab, List<Resource> resources, int enemyCount, string description, string name, int revolutionAroundDegree, float centerDistance, float scaleFactor)
    {
        RevolutionAroundDegree = revolutionAroundDegree;
        _resources = resources;
        EnemyCount = enemyCount;
        Name = name;
        Description = description;
        CenterDistance = centerDistance;
        ScaleFactor = scaleFactor;
        Prefab = prefab;
    }

    public string ID { get; } = Guid.NewGuid().ToString();
    public IReadOnlyList<IReadOnlyResource> Resources => _resources;
    public int EnemyCount { get; }
    public string Name { get; }
    public string Description { get; }
    public int RevolutionAroundDegree { get; }
    public float CenterDistance { get; }
    public float ScaleFactor { get; }
    public PlanetView Prefab { get; }
}
