using System.Collections.Generic;
using UnityEngine;

public class ResourceCellListView : MonoBehaviour
{
    [SerializeField] private ResourceCellView _prefab;
    [SerializeField] private ResourceFileView _fileView;

    [SerializeField] private Transform _organicsContainer;
    [SerializeField] private Transform _energyContainer;
    [SerializeField] private Transform _mineralContainer;

    public void RenderCells(IReadOnlyList<IReadOnlyCell> cells)
    {
        List<ResourceCellView> views = new();

        foreach (IReadOnlyCell cell in cells)
        {
            Transform transform = DefineTransform(cell.Resource);

            ResourceCellView cellView = Instantiate(_prefab, transform);
            cellView.Render(cell);

            views.Add(cellView);
        }

        _fileView.Initialize(views);
    }

    private Transform DefineTransform(IReadOnlyResource resource)
    {
        if (resource is Organics)
            return _organicsContainer;
        else if (resource is Energy)
            return _energyContainer;
        else if (resource is Mineral)
            return _mineralContainer;
        else
            return transform;
    }
}
