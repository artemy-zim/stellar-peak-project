using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelView : MonoBehaviour
{
    [SerializeField] private Slider _fuelSlider;
    [SerializeField] private TextMeshProUGUI _amount;

    public void UpdateView(int currentFuel, int maxFuel)
    {
        _fuelSlider.value = (float)currentFuel / maxFuel;
        _amount.text = $"{currentFuel}/{maxFuel}";
    }
}
