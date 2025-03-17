using System;
using UnityEngine;

public class PlanetClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event Action<string> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out PlanetView planetView))
                    Clicked?.Invoke(planetView.ID);
            }
        }
    }
}
