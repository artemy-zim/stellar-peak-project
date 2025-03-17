using System.Collections.Generic;
using UnityEngine;

public class AstronautCardListView : MonoBehaviour
{
    [SerializeField] private AstronautCardView _prefab;
    [SerializeField] private AstronautFileView _file;

    public void RenderCards(IReadOnlyList<AstronautCard> cards)
    {
        List<AstronautCardView> views = new();

        foreach (AstronautCard card in cards)
        {
            AstronautCardView cardView = Instantiate(_prefab, transform);
            cardView.Render(card);

            views.Add(cardView);
        }

        _file.Initialize(views);
    }
}
