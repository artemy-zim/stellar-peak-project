using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NationData
{
    [SerializeField] private string _nationName;                     
    [SerializeField] private List<string> _maleNames;               
    [SerializeField] private List<string> _femaleNames;             
    [SerializeField] private List<string> _maleSurnames;
    [SerializeField] private List<string> _femaleSurnames;

    public string NationName => _nationName;
    public List<string> MaleNames => _maleNames;
    public List<string> FemaleNames => _femaleNames;
    public List<string> MaleSurnames => _maleSurnames;
    public List<string> FemaleSurnames => _femaleSurnames;
}
