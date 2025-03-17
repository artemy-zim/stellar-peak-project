using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCellView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private Image _image;

    [SerializeField] private Button _button;

    private IReadOnlyResource _resource;

    public event Action<IReadOnlyResource> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnCardClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnCardClick);
    }

    public void Render(IReadOnlyCell cell)
    {
        _resource = cell.Resource;

        _count.text = cell.Count.ToString();
        _image.sprite = _resource.Sprite;
    }

    private void OnCardClick()
    {
        Clicked?.Invoke(_resource);
    }
}
