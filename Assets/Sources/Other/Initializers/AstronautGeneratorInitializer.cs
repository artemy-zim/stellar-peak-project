using UnityEngine;

public class AstronautGeneratorInitializer : MonoBehaviour
{
    [SerializeField] private AstronautCardListView _astronautListView;
    [SerializeField] private AstronautData _data;

    [SerializeField, Min(2)] private int _astronautsAmount;

    private void Awake()
    {
        AstronautGenerator generator = new AstronautGenerator(_data);
        AstronautPresenter presenter = new AstronautPresenter(_astronautListView, generator);

        presenter.GenerateAstronauts(_astronautsAmount);
    }
}
