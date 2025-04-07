using UnityEngine;

public class AstronautInfo : IReadOnlyAstronautInfo
{
    private readonly Sprite _sprite;
    private readonly string _name;
    private readonly int _age;
    private readonly AstronautGender _gender;
    private readonly string _nation;
    private readonly string _description;
    private AstronautStatus _status;

    public AstronautInfo(Sprite sprite, string name, int age, AstronautGender gender, string nation, string description)
    {
        _sprite = sprite;
        _name = name;
        _age = age;
        _gender = gender;
        _nation = nation;
        _description = description;
        _status = AstronautStatus.Alive;
    }

    public Sprite Sprite => _sprite;
    public string Name => _name;
    public int Age => _age;
    public AstronautGender Gender => _gender;
    public string Nation => _nation;
    public string Description => _description;
    public AstronautStatus Status => _status;

    public void ChangeState(AstronautStatus status)
    {
        _status = status;
    }
}
