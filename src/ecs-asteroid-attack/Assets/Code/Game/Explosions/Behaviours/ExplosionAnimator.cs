using UnityEngine;

namespace Code.Game.Common.Behaviours
{
  public class ExplosionAnimator : MonoBehaviour
  {
    [SerializeField] private ParticleSystem _explosion;

    public void Run()
    {
      _explosion.gameObject.SetActive(true); 
      _explosion.Play();
    }
  }
}