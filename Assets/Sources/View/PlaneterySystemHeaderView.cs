using TMPro;
using UnityEngine;

public class PlaneterySystemHeaderView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _resourceScore;

    private void Awake()
    {
        _header.text = GameSession.Instance.SelectedSystem.Name;

        UpdateView();
    }

    public void UpdateView()
    {
        _resourceScore.text = GameSession.Instance.Storage.ResourceScore.ToString();
    }
}
