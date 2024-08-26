using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Game.Abilities;
using Code.Game.Abilities.Configs;
using Code.Game.Hostiles;
using Code.Game.Hostiles.Configs;
using Code.Game.Player.Configs;
using Code.Infrastructure.Sounds;
using Code.Infrastructure.Sounds.Configs;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;
using UnityEngine;
using CollectionExtensions = Code.Common.Extensions.CollectionExtensions;

namespace Code.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private readonly Dictionary<WindowName, WindowConfig> _windows = new();
    private readonly Dictionary<HostileName, HostileConfig> _hostiles = new();
    private readonly Dictionary<AbilityName, AbilityConfig> _abilities = new();
    private readonly Dictionary<MusicName, AudioClip> _musicCilps = new();
    private readonly Dictionary<FxName, AudioClip> _fxCilps = new();
    private readonly List<LevelConfig> _levels = new();
    private AudioSource _audioSourcePrefab;
    private PlayerConfig _playerConfig;

    public int NumberOfLevels => _levels.Count;

    public void LoadAll()
    {
      LoadAllWindowConfig();
      LoadAllHostileConfig();
      LoadAllLevelConfig();
      LoadPlayerConfig();
      LoadAbilitiesConfig();
      LoadSoundConfig();
    }

    private void LoadPlayerConfig()
    {
      PlayerConfig[] configs = Resources.LoadAll<PlayerConfig>("Configs/Players");
      if (configs.IsNullOrEmpty() || configs.Length > 1)
        throw new Exception($"You should have only one player config. not {configs?.Length}");

      _playerConfig = configs[0];
    }

    public LevelConfig GetLevelConfig(int index) => _levels[index];
    public PlayerConfig GetPlayerConfig() => _playerConfig;
    public AbilityConfig GetAbilityConfig(AbilityName name) => _abilities[name];

    public WindowConfig GetWindowConfig(WindowName name) => _windows[name];

    public HostileConfig GetHostileConfig(HostileName name) => _hostiles[name];

    public AudioClip GetFxClip(FxName name) => _fxCilps[name];

    public AudioClip GetMusicClip(MusicName name) => _musicCilps[name];
    public AudioSource GetAudioSourcePrefab() => _audioSourcePrefab;
    
    private void LoadAllWindowConfig() => CollectionExtensions.AddRange(_windows,
      Resources.LoadAll<WindowConfig>("Configs/Windows")
        .ToDictionary(c => c.Name, c => c));

    private void LoadAllHostileConfig() => CollectionExtensions.AddRange(_hostiles,
      Resources.LoadAll<HostileConfig>("Configs/Hostiles")
        .ToDictionary(c => c.Name, c => c));

    private void LoadAbilitiesConfig() => CollectionExtensions.AddRange(_abilities,
      Resources.LoadAll<AbilityConfig>("Configs/Players/Abilities")
        .ToDictionary(c => c.Name, c => c));

    private void LoadAllLevelConfig() =>
      _levels.AddRange(Resources.LoadAll<LevelConfig>("Configs/Levels").OrderBy(c => c.Number));

    private void LoadSoundConfig() => Resources.LoadAll<SoundConfig>("Configs/Sounds").ForEach(config =>
    {
      _fxCilps.AddRange(config.Fx.ToDictionary(c => c.Name, c => c.Value));
      _musicCilps.AddRange(config.Music.ToDictionary(c => c.Name, c => c.Value));
      
      if (_audioSourcePrefab == null)
        _audioSourcePrefab = config.SourcePrefab;
    });
  }
}