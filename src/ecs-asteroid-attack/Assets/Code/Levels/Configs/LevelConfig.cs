using UnityEngine;

namespace Code.Levels.Configs
{
  [CreateAssetMenu(menuName = "Project Configs/Level")]
  public class LevelConfig : ScriptableObject
  {
    public int Number;
    public string Name;
    public string SceneName;
  }
}