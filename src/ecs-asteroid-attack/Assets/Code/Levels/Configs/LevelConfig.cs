using System.Collections.Generic;
using Code.Game.HostileSpawners.Configs;
using UnityEngine;

namespace Code.Levels.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Level")]
  public class LevelConfig : ScriptableObject
  {
    public int Number;
    public string Name;
    public string SceneName;
    public Vector3 PlayerSpawnPoint = Vector3.zero;

    public List<HostileWaveSetup> WavesSetup;
  }
}