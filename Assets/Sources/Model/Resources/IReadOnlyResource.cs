using UnityEngine;

public interface IReadOnlyResource
{
    public string ID { get; }
    public Sprite Sprite { get; }
    public string Name { get; }
    public string Description { get; }
    public Mesh Mesh { get; }
    public Material[] Materials { get; }
    public int Score { get; }
}
