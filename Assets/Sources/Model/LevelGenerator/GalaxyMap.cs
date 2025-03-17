using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GalaxyMap
{
    private List<PlaneterySystem> _systems = new();
    private Dictionary<PlaneterySystem, List<PlaneterySystem>> _connections = new();
    private readonly Fuel _fuel;

    private PlaneterySystem _currentSystem;

    public IReadOnlyFuel Fuel => _fuel;
    public IReadOnlyDictionary<PlaneterySystem, List<PlaneterySystem>> Connections => _connections;

    public GalaxyMap(Fuel fuel) 
    {
        _fuel = fuel;
    }

    public void AddSystem(PlaneterySystem system)
    {
        _systems.Add(system);
    }

    public void GenerateConnections()
    {
        foreach (var system in _systems)
        {
            var neighbors = _systems.Where(s => s != system).OrderBy(_ => Random.value).Take(Random.Range(1, 2)).ToList();
            _connections[system] = neighbors;

            foreach (var neighbor in neighbors)
            {
                if (!_connections.ContainsKey(neighbor))
                    _connections[neighbor] = new List<PlaneterySystem>();

                if (!_connections[neighbor].Contains(system))
                    _connections[neighbor].Add(system);
            }
        }
    }

    public PlaneterySystem GetSystemById(string systemId)
    {
        return _systems.FirstOrDefault(system => system.ID.Equals(systemId));
    }

    public bool IsCurrentSystem(string systemId)  
    {
        return systemId.Equals(_currentSystem.ID);
    }

    public bool CanTravelTo(string systemId)
    {
        if(_connections.TryGetValue(_currentSystem, out List<PlaneterySystem> neighbors) && _fuel.IsEnough)
            return neighbors.FirstOrDefault(neighbor => neighbor.ID.Equals(systemId)) != null;

        return false;
    }

    public void SetCurrentSystem(string systemId)
    {
        _currentSystem = _systems.FirstOrDefault(system => system.ID.Equals(systemId));
        _fuel.Spend();

        GameSession.Instance.SetSelectedSystem(_currentSystem);
    }

    public string GetRandomSystemId()
    {
        return _systems[Random.Range(0, _systems.Count)].ID;
    }
}
