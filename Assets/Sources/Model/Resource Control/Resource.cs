using System;
using UnityEngine;

[Serializable]
public class Resource : IReadOnlyResource
{
    [SerializeField] private string _id = Guid.NewGuid().ToString();
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material[] _materials;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _score;

    public string ID => _id;
    public Sprite Sprite => _sprite;
    public string Name => _name;
    public string Description => _description;
    public Mesh Mesh => _mesh;
    public Material[] Materials => _materials;
    public int Score => _score;
}
