using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneterySystem
{
    public string ID { get; } = Guid.NewGuid().ToString();
    public IReadOnlyList<SpaceBody> Planets { get; }
    public DangerLevel DangerLevel { get; }
    public Sprite Sprite { get; }
    public string Name { get; }
    public string Description { get; }

    public PlaneterySystem(List<SpaceBody> planets, DangerLevel dangerLevel, Sprite sprite, string name, string description)
    {
        Planets = planets;
        DangerLevel = dangerLevel;
        Sprite = sprite;
        Name = name;
        Description = description;
    }

    public SpaceBody SetPlanetById(string systemId)
    {
        SpaceBody planet = Planets.FirstOrDefault(planet => planet.ID.Equals(systemId));

        GameSession.Instance.SetSelectedPlanet(planet);

        return planet;
    }
}
