using UnityEngine;

public class PlanetView : MonoBehaviour
{
    public string ID { get; private set; }
    public Vector3 ObservationPoint { get; private set; }

    public void Initialize(string systemId, Transform systemRoot, float observationDistance)
    {
        ID = systemId;

        Vector3 directionToStar = (systemRoot.position - transform.position).normalized;
        ObservationPoint = transform.position + directionToStar * observationDistance;
    }
}
