using Code.Game.Abilities;
using Code.Game.Abilities.Configs;
using Code.Game.Hostiles;
using Code.Game.Hostiles.Configs;
using Code.Game.Player.Configs;
using Code.Infrastructure.Sounds;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;
using UnityEngine;

namespace Code.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    int NumberOfLevels { get; }
    
    void LoadAll();
    
    WindowConfig GetWindowConfig(WindowName name);
    
    LevelConfig GetLevelConfig(int index);
    
    PlayerConfig GetPlayerConfig();
    
    AbilityConfig GetAbilityConfig(AbilityName name);
    
    HostileConfig GetHostileConfig(HostileName name);
    
    AudioClip GetFxClip(FxName name);
    
    AudioClip GetMusicClip(MusicName name);
    AudioSource GetAudioSourcePrefab();
  }
}