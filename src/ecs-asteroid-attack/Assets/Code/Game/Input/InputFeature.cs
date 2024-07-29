using Code.Game.Input.Systems;
using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Input
{
  public class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
    }
  }
}