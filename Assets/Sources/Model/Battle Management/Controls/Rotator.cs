using UnityEngine;

public class Rotator
{
    private readonly Camera _camera;
    private readonly LayerMask _groundLayer;

    public Rotator(Camera camera, LayerMask groundLayer)
    {
        _camera = camera;
        _groundLayer = groundLayer;
    }

    public Quaternion GetRotation(Vector3 position)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
        {
            Vector3 direction = hit.point - position;
            direction.y = 0;

            return Quaternion.LookRotation(direction);
        }

        return Quaternion.identity;
    }
}
