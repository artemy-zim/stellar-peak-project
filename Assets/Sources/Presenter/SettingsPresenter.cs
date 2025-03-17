using TMPro;
using UnityEngine;

public class SettingsPresenter
{
    private readonly SettingsView _view;
    private readonly SettingsManager _manager;

    public SettingsPresenter(SettingsView view, SettingsManager manager)
    {
        _view = view;
        _manager = manager;

        InitializeView();
        BindView();
    }

    private void InitializeView()
    {
        _view.ResolutionDropdown.ClearOptions();

        foreach (var resolution in Screen.resolutions)
            _view.ResolutionDropdown.options.Add(new TMP_Dropdown.OptionData($"{resolution.width}x{resolution.height}"));

        _view.ResolutionDropdown.value = _manager.Settings.General.ResolutionIndex;

        _view.QualityDropdown.value = _manager.Settings.General.QualityIndex;
        _view.VSyncToggle.isOn = _manager.Settings.General.IsVSyncEnabled;

        _view.MasterVolumeSlider.value = _manager.Settings.Audio.MasterVolume;
        _view.MusicVolumeSlider.value = _manager.Settings.Audio.MusicVolume;
        _view.UISoundsVolumeSlider.value = _manager.Settings.Audio.UISoundsVolume;
        _view.GameplaySoundsVolumeSlider.value = _manager.Settings.Audio.GameplaySoundsVolume;

    }

    private void BindView()
    {
        _view.SaveButton.onClick.AddListener(SaveSettings);
        _view.ResolutionDropdown.onValueChanged.AddListener(index => _manager.Settings.General.ResolutionIndex = index);
        _view.QualityDropdown.onValueChanged.AddListener(index => _manager.Settings.General.QualityIndex = index);
        _view.VSyncToggle.onValueChanged.AddListener(isOn => _manager.Settings.General.IsVSyncEnabled = isOn);
        _view.MasterVolumeSlider.onValueChanged.AddListener(value => _manager.Settings.Audio.MasterVolume = value);
        _view.MusicVolumeSlider.onValueChanged.AddListener(value => _manager.Settings.Audio.MusicVolume = value);
        _view.UISoundsVolumeSlider.onValueChanged.AddListener(value => _manager.Settings.Audio.UISoundsVolume = value);
        _view.GameplaySoundsVolumeSlider.onValueChanged.AddListener(value => _manager.Settings.Audio.GameplaySoundsVolume = value);
    }

    private void SaveSettings()
    {
        _manager.SaveSettings();
        _manager.ApplySettings();
    }
}
