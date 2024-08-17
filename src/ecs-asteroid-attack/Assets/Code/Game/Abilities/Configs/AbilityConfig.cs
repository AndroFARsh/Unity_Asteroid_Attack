using System.Collections.Generic;
using Code.Common.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Game.Abilities.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Ability")]
  public class AbilityConfig : ScriptableObject
  {
    public AbilityName Name;
    public EntityViewBehaviour ViewPrefabs;
    
    public float Cooldown = 1;

    public ProjectileSetup ProjectileSetup;
  }
}