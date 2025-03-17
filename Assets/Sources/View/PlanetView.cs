using UnityEngine;

public class PlanetView : MonoBehaviour
{
    public string ID { get; private set; }

    public void Initialize(string systemId)
    {
        ID = systemId;
    }
}
