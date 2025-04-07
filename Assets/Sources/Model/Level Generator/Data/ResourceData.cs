using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Game/ResourceData")]
public class ResourceData : ScriptableObject
{
    [SerializeField] private List<Mineral> _minerals;
    [SerializeField] private List<Organics> _organics;
    [SerializeField] private List<Energy> _energies;

    public List<Resource> GetResourcePack(int resourceAmount)
    {
        if (resourceAmount <= 0) 
            return new List<Resource>();

        List<Resource> resourcePack = new();

        int mineralCount = Mathf.Max(1, resourceAmount / 3);
        int organicCount = Mathf.Max(1, resourceAmount / 3);
        int energyCount = resourceAmount - (mineralCount + organicCount);

        AddRandomResources(resourcePack, _minerals, mineralCount);
        AddRandomResources(resourcePack, _organics, organicCount);
        AddRandomResources(resourcePack, _energies, energyCount);

        return resourcePack;
    }

    private void AddRandomResources<T>(List<Resource> resourcePack, List<T> resourceList, int count) where T : Resource
    {
        if (resourceList == null || resourceList.Count == 0) 
            return;

        for (int i = 0; i < count; i++)
        {
            T randomResource = resourceList[Random.Range(0, resourceList.Count)];
            resourcePack.Add(randomResource);
        }
    }
}
