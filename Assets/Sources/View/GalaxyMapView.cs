using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyMapView : MonoBehaviour
{
    [SerializeField] private PlaneterySystemMapView nodePrefab;
    [SerializeField] private RectTransform canvasParent;
    [SerializeField] private Material lineMaterial;
    [SerializeField] private PlaneterySystemCardView _cardView;
    [SerializeField] private float lineWidth;

    private readonly List<PlaneterySystemMapView> _nodes = new();

    public event Action<string> SystemSelected;

    public void Initialize(IReadOnlyDictionary<PlaneterySystem, List<PlaneterySystem>> connections)
    {
        foreach (var (from, toList) in connections)
        {
            foreach (PlaneterySystem to in toList)
                DrawLine(GetNodePosition(from), GetNodePosition(to));
        }
    }

    public void AddNode(Vector3 position, PlaneterySystem system)
    {
        PlaneterySystemMapView node = Instantiate(nodePrefab, canvasParent);
        RectTransform rect = node.GetComponent<RectTransform>();
        rect.anchoredPosition = position;

        node.Initialize(system.Planets.Count, system.DangerLevel, system.Sprite, system.Name, system.ID);

        node.Clicked += id => SystemSelected?.Invoke(id);

        _nodes.Add(node);
    }

    public void SetPlayerSystem(string id)
    {
        PlaneterySystemMapView systemView = _nodes.FirstOrDefault(node => node.ID.Equals(id));

        foreach (var node in _nodes)
            node.HidePlayerMark();

        systemView.ShowPlayerMark();
    }

    public void ShowSystemInfo(PlaneterySystem system)
    {
        _cardView.Render(system);
    }

    private Vector3 GetNodePosition(PlaneterySystem system)
    {
        return _nodes.FirstOrDefault(node => node.ID.Equals(system.ID)).transform.position;
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject line = new("Line", typeof(LineRenderer));
        LineRenderer lr = line.GetComponent<LineRenderer>();

        Vector3 startWorld = RectTransformUtility.WorldToScreenPoint(null, start);
        Vector3 endWorld = RectTransformUtility.WorldToScreenPoint(null, end);

        lr.positionCount = 2;
        lr.SetPosition(0, Camera.main.ScreenToWorldPoint(new Vector3(startWorld.x, startWorld.y, Camera.main.nearClipPlane + 0.01f)));
        lr.SetPosition(1, Camera.main.ScreenToWorldPoint(new Vector3(endWorld.x, endWorld.y, Camera.main.nearClipPlane + 0.01f)));
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = new Material(lineMaterial);
        lr.startColor = Color.white;
        lr.endColor = Color.white;
    }

    private void OnDestroy()
    {
        foreach(PlaneterySystemMapView node in _nodes)
            node.Clicked -= id => SystemSelected?.Invoke(id);
    }
}
