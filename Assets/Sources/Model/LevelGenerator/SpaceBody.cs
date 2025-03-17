using System;
using System.Collections.Generic;

public class SpaceBody
{
    private List<Resource> _resources;

    public SpaceBody(List<Resource> resources, int enemyCount, string description, string name, int revolutionAroundDegree, float centerDistance, float scaleFactor)
    {
        RevolutionAroundDegree = revolutionAroundDegree;
        _resources = resources;
        EnemyCount = enemyCount;
        Name = name;
        Description = description;
        CenterDistance = centerDistance;
        ScaleFactor = scaleFactor;
    }

    public string ID { get; } = Guid.NewGuid().ToString();
    public IReadOnlyList<IReadOnlyResource> Resources => _resources;
    public int EnemyCount { get; }
    public string Name { get; }
    public string Description { get; }
    public int RevolutionAroundDegree { get; }
    public float CenterDistance { get; }
    public float ScaleFactor { get; }
}
