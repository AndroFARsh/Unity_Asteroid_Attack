using UnityEngine;

namespace Code.Infrastructure.Windows.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Window")]
  public class WindowConfig : ScriptableObject
  {
    public WindowName Name;
    public BaseWindow Prefab;
  }
}