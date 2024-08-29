using System;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.PersistentData.Data;
using Code.Infrastructure.Sounds;
using UnityEngine;

namespace Code.Home.Windows.Services
{
  class SettingsUIService : ISettingsUIService
  {
    
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly ISoundService _soundService;

    public float CurrentMusicVolume { get; private set; }
    
    public float CurrentEffectVolume { get; private set; }
    
    private SettingsUIService(IPersistentDataProvider persistentDataProvider, ISoundService soundService)
    {
      _persistentDataProvider = persistentDataProvider;
      _soundService = soundService;
    }

    public void Initialize()
    {
      UpdateMusicVolume(_persistentDataProvider.SettingsData.MusicVolume);
      UpdateEffectVolume(_persistentDataProvider.SettingsData.EffectVolume);
    }

    public void UpdateMusicVolume(float value)
    {
      CurrentMusicVolume = Mathf.Clamp01(value);
      _soundService.MusicVolumeChanged(CurrentMusicVolume);
    }

    public void UpdateEffectVolume(float value)
    {
      CurrentEffectVolume = Mathf.Clamp01(value);
      _soundService.EffectVolumeChanged(CurrentEffectVolume);
    }

    public void Reset()
    {
      UpdateMusicVolume(_persistentDataProvider.SettingsData.MusicVolume);
      UpdateEffectVolume(_persistentDataProvider.SettingsData.EffectVolume);
    }
    
    public void Apply()
    {
      _persistentDataProvider.SettingsData.MusicVolume = CurrentMusicVolume;
      _persistentDataProvider.SettingsData.EffectVolume = CurrentEffectVolume;
    }

    public void ResetProgress() => _persistentDataProvider.SetProgressData(new ProgressData());
  }
}