using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Sounds.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Sound")]
  public class SoundConfig : ScriptableObject
  {
    public List<MusicSetup> Music;
    public List<FxSetup> Fx;
    
    public AudioSource SourcePrefab;
  }
}