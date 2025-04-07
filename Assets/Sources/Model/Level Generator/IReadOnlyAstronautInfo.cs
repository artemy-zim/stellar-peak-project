using UnityEngine;

public interface IReadOnlyAstronautInfo
{
    public Sprite Sprite { get; }
    public string Name { get; }
    public int Age { get; }
    public AstronautGender Gender { get; }
    public string Nation { get; }
    public string Description { get; }
    public AstronautStatus Status { get; }
}
