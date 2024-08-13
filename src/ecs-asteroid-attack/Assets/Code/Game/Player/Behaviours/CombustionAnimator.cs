using UnityEngine;

namespace Code.Game.Player.Behaviours
{
  public class CombustionAnimator : MonoBehaviour
  {
    [SerializeField] private ParticleSystem _main;
    [SerializeField] private ParticleSystem _left;
    [SerializeField] private ParticleSystem _right;
    
    public void RunMain(bool run) => _main.gameObject.SetActive(run);
    
    public void RunLeft(bool run) => _left.gameObject.SetActive(run);
    
    public void RunRight(bool run) => _right.gameObject.SetActive(run); 
  }
}