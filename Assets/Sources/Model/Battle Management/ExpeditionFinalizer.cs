using UnityEngine;
using UnityEngine.Events;

public class ExpeditionFinalizer : MonoBehaviour
{
    [SerializeField] private UnityEvent Processed;

    private Inventory _inventory;

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void ProcessSuccess()
    {
        Storage storage = GameSession.Instance.Storage;
        storage.Add(_inventory.CollectedResources);

        Processed?.Invoke();
    }

    public void ProcessFailure()
    {
        GameSession.Instance.ChosenAstronaut.Decease();

        Processed?.Invoke();
    }
}
