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
    
    public float RotateMinSpeed = 0;
    public float RotateMaxSpeed = 60;
    
    public float MinMoveSpeed = 0.5f;
    public float MaxMoveSpeed = 2f;
  }
}