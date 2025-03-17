using System;
using UnityEngine;

public class ResourceView : MonoBehaviour, ISpawnable, IInteractable
{
    [SerializeField] private ParticleSystem _spotParticleSystem;
    [SerializeField] private ParticleSystem _spawnParticleSystem;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private BoxCollider _boxCollider;

    private string _id;

    public string ID => _id;

    public event Action<string> Interacted;

    public void Init(Mesh mesh, Material[] materials, string id)
    {
        _meshFilter.mesh = mesh;
        _meshRenderer.materials = materials;
        _id = id;

        _boxCollider.size = _meshFilter.mesh.bounds.size;
        _boxCollider.center = _meshFilter.mesh.bounds.center;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ResourceCollector _))
            _spotParticleSystem.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ResourceCollector _))
            _spotParticleSystem.Stop();
    }

    public void OnSpawn()
    {
        _spawnParticleSystem.Play();
    }

    public void Interact()
    {
        Interacted?.Invoke(_id);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
