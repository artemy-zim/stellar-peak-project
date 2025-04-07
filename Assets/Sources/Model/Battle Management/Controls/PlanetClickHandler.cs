using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlanetClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private UnityEvent _clicked;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isReturning = false;
    private bool isMoving = false;

    public event Action<string> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReturning && !isMoving)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out PlanetView planetView))
                {
                    Clicked?.Invoke(planetView.ID);
                    _clicked?.Invoke();
                    MoveToPlanet(planetView);
                }
            }
        }
    }

    public void MoveBack()
    {
        if(!isReturning && !isMoving)
            StartCoroutine(MoveCamera(originalPosition, originalRotation));
    }

    private void MoveToPlanet(PlanetView planetView)
    {
        if (isMoving || isReturning) return;

        originalPosition = _camera.transform.position;
        originalRotation = _camera.transform.rotation;

        Vector3 targetPosition = planetView.ObservationPoint;
        Quaternion targetRotation = Quaternion.LookRotation(planetView.transform.position - targetPosition);

        StartCoroutine(MoveCamera(targetPosition, targetRotation));
    }

    private IEnumerator MoveCamera(Vector3 targetPosition, Quaternion targetRotation)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 startPosition = _camera.transform.position;
        Quaternion startRotation = _camera.transform.rotation;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = movementCurve.Evaluate(elapsedTime / moveDuration);

            _camera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            _camera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            yield return null;
        }

        _camera.transform.position = targetPosition;
        _camera.transform.rotation = targetRotation;
        isMoving = false;
    }
}
