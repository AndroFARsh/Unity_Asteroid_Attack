using Code.Common.View;
using UnityEngine;

namespace Code.Game.Player.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Player")]
  public class PlayerConfig : ScriptableObject
  {
    public EntityViewBehaviour ViewPrefab;
    
    public float RotateSpeed = 60;
    public float MoveAcceleration = 1;
    public float MaxMoveSpeed = 3;
    public int MaxLives = 3;
    public Vector2 InitialMoveDirection = Vector2.up;
    public Vector2 PlayerSpawnPoint = Vector2.zero;
  }
}