using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AstronautCardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _image;

    [SerializeField] private Button _button;

    private AstronautCard _card;

    public event Action<AstronautCard> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnCardClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnCardClick);
    }

    public void Render(AstronautCard card)
    {
        if(card.Info.Status == AstronautStatus.Deceased)
            _button.enabled = false;

        _card = card;

        _image.sprite = card.Info.Sprite;
        _name.text = card.Info.Name;
    }

    private void OnCardClick()
    {
        Clicked?.Invoke(_card);
        GameSession.Instance.SetSelectedAstronaut(_card);
    }
}
