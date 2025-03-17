using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfoPanel : MonoBehaviour
{
    [SerializeField] private Window _window;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Image _resourcePortrait;
    [SerializeField] private Button _actionButton;

    public event Action Clicked;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnActionButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnActionButtonClick);
    }

    public void UpdateView(Sprite sprite, string name)
    {
        _resourcePortrait.sprite = sprite;
        _title.text = name;

        _window.Show();
    }

    private void OnActionButtonClick()
    {
        _window.Hide();
        Clicked?.Invoke();
    }
}
