using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private PlayerControlView _controls;

    private List<IInteractable> _interactables = new();

    private void OnEnable()
    {
        _controls.OnInteract.AddListener(TryInteract);
    }

    private void OnDisable()
    {
        _controls.OnInteract.RemoveListener(TryInteract);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
            _interactables.Add(interactable);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
            _interactables.Remove(interactable);
    }

    private void TryInteract()
    {
        if (_interactables.Count == 0)
            return;

        _interactables.Last().Interact();
    }
}
