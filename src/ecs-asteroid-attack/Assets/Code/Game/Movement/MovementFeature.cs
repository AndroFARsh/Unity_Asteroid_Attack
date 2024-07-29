using Code.Game.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Movement
{
  public sealed class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systems)
    {
      Add(systems.Create<MoveAlongDirectionSystem>());
      Add(systems.Create<RotateAlongRotationInputSystem>());
    }
  }
}