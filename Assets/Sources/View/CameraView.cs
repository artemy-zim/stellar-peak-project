using UnityEngine;

public class CameraView : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Init(Vector3 position)
    {
        transform.position = position;  
    }

    public void SetPosition(Vector3 position)
    {
        _transform.position = position;
    }
}
