using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AstronautGenerator
{
    private readonly AstronautData _data;
    private readonly List<Sprite> _takenSprites = new();

    public AstronautGenerator(AstronautData data)
    {
        _data = data;
    }

    public List<AstronautCard> GenerateAstronauts(int count)
    {
        List<AstronautCard> astronauts = new();

        for (int i = 0; i < count; i++)
        {
            AstronautInfo info = GenerateInfo();
            AstronautStats stats = GenerateStats();

            astronauts.Add(new AstronautCard(info, stats));
        }

        return astronauts;
    }

    private AstronautInfo GenerateInfo()
    {
        NationData selectedNation = _data.NationData[Random.Range(0, _data.NationData.Count)];
        AstronautGender gender = (AstronautGender)Random.Range(0, 2);

        string name = gender == AstronautGender.Male
        ? selectedNation.MaleNames[Random.Range(0, selectedNation.MaleNames.Count)]
        : selectedNation.FemaleNames[Random.Range(0, selectedNation.FemaleNames.Count)];

        string surname = gender == AstronautGender.Male
            ? selectedNation.MaleSurnames[Random.Range(0, selectedNation.MaleSurnames.Count)]
            : selectedNation.FemaleSurnames[Random.Range(0, selectedNation.FemaleSurnames.Count)];

        string fullName = $"{name} {surname}";

        Sprite sprite = gender == AstronautGender.Male
            ? _data.MaleSprites.ToList()[Random.Range(0, _data.MaleSprites.Count)]
            : _data.FemaleSprites.ToList()[Random.Range(0, _data.FemaleSprites.Count)];

        int age = Random.Range(_data.MinAge, _data.MaxAge);

        string description = DescriptionFormatter.FormatDescription(_data.Descriptions[Random.Range(0, _data.Descriptions.Count)], gender, fullName, selectedNation.NationName);

        _takenSprites.Add(sprite);

        return new AstronautInfo(sprite, fullName, age, gender, selectedNation.NationName, description);
    }

    private AstronautStats GenerateStats()
    {
        float speed = Random.Range(_data.MinSpeed, _data.MaxSpeed);
        int capacity = Random.Range(_data.MinCapacity, _data.MaxCapacity);
        int health = Random.Range(_data.MinHealth, _data.MaxHealth);

        return new AstronautStats(speed, capacity, health, _data.MaxAllowedSpeed, _data.MaxAllowedHealth, _data.MaxAllowedCapacity);
    }
}
