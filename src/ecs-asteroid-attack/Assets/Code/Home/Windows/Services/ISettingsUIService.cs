using System;

namespace Code.Home.Windows.Services
{
  public interface ISettingsUIService
  {
    float CurrentMusicVolume { get; }
    
    void UpdateMusicVolume(float value);
    
    float CurrentEffectVolume { get; }
    
    void UpdateEffectVolume(float value);

    void Initialize();
    
    void Reset();
    void Apply();
  }
}