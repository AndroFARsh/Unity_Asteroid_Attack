using Code.Levels.UI.LevelsButton;
using UnityEngine;

namespace Code.Levels.UI.Factories
{
  public interface ILevelButtonFactory
  {
    LevelButtonUIView CreateButton(Transform at);
  }
}