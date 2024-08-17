using UnityEngine;

namespace Code.Game.Player.Behaviours
{
  public class ProjectileSpawner : MonoBehaviour
  {
    [SerializeField] private Transform _transform;

    public Vector2 Position => _transform.position;
    
    public Vector2 Direction => _transform.up;
  }
}