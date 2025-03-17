using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Window))]
public class AstronautFileView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _general;
    [SerializeField] private TextMeshProUGUI _description;

    private Window _window;

    public void Initialize(IReadOnlyList<AstronautCardView> cards)
    {
        foreach(AstronautCardView card in cards)
            card.Clicked += Render;

        _window = GetComponent<Window>();
        _window.ValidateIfNull();
    }

    public void Render(AstronautCard card)
    {
        _window.Show();

        _image.sprite = card.Info.Sprite;

        _general.text = $"NAME: {card.Info.Name}\n" +
                        $"AGE: {card.Info.Age}\n" +
                        $"GENDER: {card.Info.Gender}\n" +
                        $"NATION: {card.Info.Nation}\n" +
                        $"SPEED: {GetStatView(card.Stats.Speed)}\n" +
                        $"CAPACITY: {GetStatView(card.Stats.Capacity)}\n" +
                        $"HEALTH: {GetStatView(card.Stats.Health)}\n";

        _description.text = card.Info.Description;
    }

    private string GetStatView(float stat)
    {
        Color[] colors = new Color[] {
            Color.gray,
            Color.white,
            Color.green,
            Color.cyan,
            Color.blue,
            Color.yellow,
            Color.red
        };

        string[] ranks = new string[]
        {
            "F",
            "E",
            "D",
            "C",
            "B",
            "A",
            "S"
        };

        int counter = 0;
        float rankThreshold = 2;

        while (stat > rankThreshold)
        {
            rankThreshold += rankThreshold;

            counter++;
        }

        if(counter >= ranks.Length)
            counter = ranks.Length - 1;

        string colorHex = ColorUtility.ToHtmlStringRGB(colors[counter]);

        return $"<color=#{colorHex}>{ranks[counter]}</color>";
    }
}
