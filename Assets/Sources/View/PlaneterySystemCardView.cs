using System;
using System.Linq;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Window))]
public class PlaneterySystemCardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _discoveryDate;
    [SerializeField] private TextMeshProUGUI _organicsCount;
    [SerializeField] private TextMeshProUGUI _mineralsCount;
    [SerializeField] private TextMeshProUGUI _energyCount;
    [SerializeField] private TextMeshProUGUI _planetsCount;
    [SerializeField] private TextMeshProUGUI _dangerLevel;
    [SerializeField] private TextMeshProUGUI _description;

    private Window _window;

    private void Awake()
    {
        _window = GetComponent<Window>();
        _window.ValidateIfNull();
    }

    public void Render(PlaneterySystem system)
    {
        _name.text = system.Name;
        _discoveryDate.text = $"Discovery Date: {DateTime.Now:yyyy-MM-dd}";
        _organicsCount.text = $"x{system.Planets.SelectMany(planet => planet.Resources).Count(resource => resource is Organics)}";
        _mineralsCount.text = $"x{system.Planets.SelectMany(planet => planet.Resources).Count(resource => resource is Mineral)}";
        _energyCount.text = $"x{system.Planets.SelectMany(planet => planet.Resources).Count(resource => resource is Energy)}";
        _planetsCount.text = $"Planets: {system.Planets.Count}";
        _dangerLevel.text = $"Danger level: {system.DangerLevel}";
        _description.text = $"Info: {system.Description}";

        _window.Show();
    }
}
