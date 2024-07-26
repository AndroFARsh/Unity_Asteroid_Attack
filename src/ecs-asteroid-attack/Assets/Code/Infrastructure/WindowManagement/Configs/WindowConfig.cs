using Code.Infrastructure.WindowManagement.Behaviours;
using UnityEngine;

namespace Code.Infrastructure.WindowManagement.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Window")]
  public class WindowConfig : ScriptableObject
  {
    public WindowName Name;
    public BaseWindow Prefab;
  }
}