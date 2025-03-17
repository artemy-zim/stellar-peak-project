using UnityEngine.Audio;
using UnityEngine;

public class SettingsManager
{
    private readonly AudioMixer _audioMixer;
    private readonly Settings _settings;

    public Settings Settings => _settings;

    public SettingsManager(AudioMixer mixer)
    {
        _settings = JsonFileHandler.LoadFromFile<Settings>();
        _audioMixer = mixer;
    }

    public void SaveSettings()
    {
        JsonFileHandler.SaveToFile(_settings);
    }

    public void ApplySettings()
    {
        ApplyGraphicsSettings();
        ApplyAudioSettings();
    }

    private void ApplyGraphicsSettings()
    {
        GeneralSettings general = _settings.General;

        Resolution resolution = Screen.resolutions[general.ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);

        QualitySettings.SetQualityLevel(general.QualityIndex);
        QualitySettings.vSyncCount = general.IsVSyncEnabled ? 1 : 0;
    }

    private void ApplyAudioSettings()
    {
        AudioSettings audio = _settings.Audio;
        int audioConstant = 20;

        _audioMixer.SetFloat(AudioData.Params.MasterVolume, Mathf.Log10(audio.MasterVolume) * audioConstant);
        _audioMixer.SetFloat(AudioData.Params.MusicVolume, Mathf.Log10(audio.MusicVolume) * audioConstant);
        _audioMixer.SetFloat(AudioData.Params.UIVolume, Mathf.Log10(audio.UISoundsVolume) * audioConstant);
        _audioMixer.SetFloat(AudioData.Params.SoundsVolume, Mathf.Log10(audio.GameplaySoundsVolume) * audioConstant);
    }
}
