using System.Linq;
using System;
using UnityEngine;
using TMPro;

[RequireComponent (typeof(Window))]
public class PlanetCardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _discoveryDate;
    [SerializeField] private TextMeshProUGUI _organicsCount;
    [SerializeField] private TextMeshProUGUI _mineralsCount;
    [SerializeField] private TextMeshProUGUI _energyCount;
    [SerializeField] private TextMeshProUGUI _enemiesAmount;
    [SerializeField] private TextMeshProUGUI _description;

    private Window _window;

    private void Awake()
    {
        _window = GetComponent<Window>();
        _window.ValidateIfNull();
    }

    public void Render(SpaceBody planet)
    {
        _name.text = planet.Name;
        _discoveryDate.text = $"Discovery Date: {DateTime.Now:yyyy-MM-dd}";
        _organicsCount.text = $"x{planet.Resources.Count(resource => resource is Organics)}";
        _mineralsCount.text = $"x{planet.Resources.Count(resource => resource is Mineral)}";
        _energyCount.text = $"x{planet.Resources.Count(resource => resource is Energy)}";
        _enemiesAmount.text = $"Enemies: {planet.EnemyCount}";
        _description.text = $"Info: {planet.Description}";

        _window.Show();
    }
}
