using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneterySystemMapView : MonoBehaviour
{
    [SerializeField] private Image _systemImage;
    [SerializeField] private Image _playerMark;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _planetsCount;
    [SerializeField] private TextMeshProUGUI _dangerLevel;
    [SerializeField] private Button _button;

    public string ID { get; private set; }

    public event Action<string> Clicked;

    public void Initialize(int planetsCount, DangerLevel dangerLevel, Sprite image, string name, string id)
    {
        HidePlayerMark();

        ID = id;
        _systemImage.sprite = image;
        _nameText.text = name;
        _planetsCount.text = "Planets: " + planetsCount.ToString();
        _dangerLevel.text = "Danger level: " + dangerLevel.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() => Clicked?.Invoke(ID));
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => Clicked?.Invoke(ID));
    }

    public void ShowPlayerMark()
    {
        _playerMark.gameObject.SetActive(true);
    }

    public void HidePlayerMark()
    {
        _playerMark.gameObject.SetActive(false);
    }
}
