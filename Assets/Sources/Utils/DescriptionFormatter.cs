using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DescriptionFormatter
{
    private static readonly string pronounMale = "he";
    private static readonly string pronounFemale = "she";
    private static readonly string possessivePronounMale = "his";
    private static readonly string possessivePronounFemale = "her";

    public static string FormatDescription(string template, AstronautGender gender, string name, string nation)
    {
        string heShe = gender == AstronautGender.Male ? pronounMale : pronounFemale;
        string hisHer = gender == AstronautGender.Male ? possessivePronounMale : possessivePronounFemale;

        string formattedDescription = template
            .Replace("{he_she}", heShe)
            .Replace("{his_her}", hisHer)
            .Replace("{name}", name)
            .Replace("{nation}", nation);

        return formattedDescription;
    }
}
