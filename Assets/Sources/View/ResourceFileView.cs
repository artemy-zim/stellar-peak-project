using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceFileView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _description;

    private Window _window;

    public void Initialize(IReadOnlyList<ResourceCellView> cells)
    {
        foreach (ResourceCellView cell in cells)
            cell.Clicked += Render;

        _window = GetComponent<Window>();
        _window.ValidateIfNull();
    }

    public void Render(IReadOnlyResource resource)
    {
        _window.Show();

        _image.sprite = resource.Sprite;
        _header.text = resource.Name;
        _description.text = resource.Description;
        _score.text = resource.Score.ToString();
    }
}
