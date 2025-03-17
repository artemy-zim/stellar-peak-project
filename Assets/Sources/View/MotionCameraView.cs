using UnityEngine;

public class MotionCameraView : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private void OnValidate()
    {
        if (transform == null)
            Debug.LogWarning($"{_transform.GetType().Name} is not assigned in {gameObject.name}");
    }

    public void Move(Vector3 position)
    {
        _transform.position = position;
    }

    public void Rotate(Vector3 rotation)
    {
        _transform.Rotate(rotation);
    }

    public void SetAngle(Vector3 angle)
    {
        _transform.rotation = Quaternion.Euler(angle);
    }

    public Vector3 GetPosition()
    {
        return _transform.position;
    }
}
