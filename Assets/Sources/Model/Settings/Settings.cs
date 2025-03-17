[System.Serializable]
public class Settings
{
    public GeneralSettings General { get; set; } = new GeneralSettings();
    public AudioSettings Audio { get; set; } = new AudioSettings();
}
