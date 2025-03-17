using UnityEngine;
using UnityEngine.Events;

public class PlayerControlView : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _shotPoint;

    public UnityEvent OnInteract;
    public UnityEvent OnShoot;

    private Transform _transform;

    public bool IsGrounded => _controller.isGrounded;
    public Vector3 GetShotPoint() => _shotPoint.position;
    public Quaternion GetRotation() => transform.rotation;


    private void Awake()
    {
        _transform = transform;
    }

    public void CallOnShoot()
    {
        OnShoot?.Invoke();
    }

    public void CallOnInteract()
    {
        OnInteract?.Invoke();
    }

    public void SetMovement(Vector3 movement)
    {
        _controller.Move(movement);
    }

    public void SetRotation(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }
}
