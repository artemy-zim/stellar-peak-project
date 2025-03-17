using UnityEngine;
using UnityEngine.Audio;

public class SettingsInitializer : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private SettingsView settingsView;

    private SettingsManager _settingsManager;
    private SettingsPresenter _settingsPresenter;

    private void Awake()
    {
        _settingsManager = new(_mixer);
        _settingsPresenter = new(settingsView, _settingsManager);
        _settingsManager.ApplySettings();
    }
}
