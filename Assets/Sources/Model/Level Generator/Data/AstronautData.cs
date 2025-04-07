using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AstronautData", menuName = "Game/AstronautData")]
public class AstronautData : ScriptableObject
{
    [SerializeField] private List<NationData> _nationData;
    [SerializeField] private List<Sprite> _femaleSprites;
    [SerializeField] private List<Sprite> _maleSprites;
    [SerializeField] private List<string> _descriptions;
    [SerializeField] private int _maxAge;
    [SerializeField] private int _minAge;
    [SerializeField] private int _minCapacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private int _minHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private int _maxAllowedHealth;
    [SerializeField] private int _maxAllowedCapacity;
    [SerializeField] private float _maxAllowedSpeed;

    public IReadOnlyList<NationData> NationData => _nationData;
    public IReadOnlyList<Sprite> FemaleSprites => _femaleSprites;
    public IReadOnlyList<Sprite> MaleSprites => _maleSprites;
    public IReadOnlyList<string> Descriptions => _descriptions;
    public int MaxAge => _maxAge;
    public int MinAge => _minAge;
    public int MinCapacity => _minCapacity;
    public int MaxCapacity  => _maxCapacity;
    public int MinHealth => _minHealth;
    public int MaxHealth => _maxHealth;
    public float MinSpeed => _minSpeed;
    public float MaxSpeed => _maxSpeed;
    public float MaxAllowedSpeed => _maxAllowedSpeed;
    public int MaxAllowedCapacity => _maxAllowedCapacity;
    public int MaxAllowedHealth => _maxAllowedHealth;
}
