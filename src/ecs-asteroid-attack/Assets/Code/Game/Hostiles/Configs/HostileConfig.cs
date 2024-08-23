using System.Collections.Generic;
using Code.Common.View;
using UnityEngine;

namespace Code.Game.Hostiles.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Hostile")]
  public class HostileConfig : ScriptableObject
  {
    public HostileName Name;
    public List<EntityViewBehaviour> ViewPrefabs;
    
    public float MinTorqueImpuls = 10;
    public float MaxTorqueImpuls = 30;
    
    public float MinMoveImpuls = 70f;
    public float MaxMoveImpuls = 120f;
    
    public int MinShards = 0;
    public int MaxShards = 0;
    public List<HostileName> Shards;
  }
}