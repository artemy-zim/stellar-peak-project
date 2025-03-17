using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class PlanetarySystemGenerator : MonoBehaviour
{
    [SerializeField] private SpaceBodyData _spaceBodyData;
    [SerializeField] private PlaneterySystemData _planeterySystemData;
    [SerializeField] private ResourceData _resourceData;

    private int _maxRevolutionAroundDegree = 360;

    public PlaneterySystem GenerateSystemModel()
    {
        List<SpaceBody> planets = new(Random.Range(_planeterySystemData.MinPlanetsCount, _planeterySystemData.MaxPlanetsCount));
        float centerDistance = 0f;

        for (int i = 0; i < planets.Capacity; i++)
        {
            List<Resource> resources = _resourceData.GetResourcePack(Random.Range(_spaceBodyData.MinResourceCount, _spaceBodyData.MaxResourceCount));
            int enemyCount = GenerateEnemiesCount(resources.Count);
            centerDistance += Random.Range(_spaceBodyData.MinDistance, _spaceBodyData.MaxDistance);

            planets.Add(new SpaceBody(resources, enemyCount, _spaceBodyData.Descriptions[Random.Range(0, _spaceBodyData.Descriptions.Count)], _spaceBodyData.Names[Random.Range(0, _spaceBodyData.Names.Count)], Random.Range(0, _maxRevolutionAroundDegree), centerDistance, Random.Range(_spaceBodyData.MinScaleFactor, _spaceBodyData.MaxScaleFactor)));
        }

        Sprite image = _planeterySystemData.Sprites[Random.Range(0, _planeterySystemData.Sprites.Count)];
        DangerLevel dangerLevel = GetDangerLevel(planets.Sum(p => p.EnemyCount));

        return new PlaneterySystem(planets, dangerLevel, image, _planeterySystemData.Names[Random.Range(0, _planeterySystemData.Names.Count)], _planeterySystemData.Descriptions[Random.Range(0, _planeterySystemData.Descriptions.Count)]);
    }

    private DangerLevel GetDangerLevel(int enemyCount)
    {
        if (enemyCount == 0)
            return DangerLevel.Safe;
        else if (enemyCount < _planeterySystemData.MaxPlanetsCount / 2)
            return DangerLevel.Moderate;
        else
            return DangerLevel.Dangerous;
    }

    private int GenerateEnemiesCount(int resourceAmount)
    {
        return Random.Range(0, resourceAmount > _spaceBodyData.MaxEnemyCount ? _spaceBodyData.MaxEnemyCount : resourceAmount);
    }
}
