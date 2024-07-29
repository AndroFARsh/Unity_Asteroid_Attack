using Code.Common.EntityFactories;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    private readonly IEntityFactory _entityFactory;

    InitializeInputSystem(IEntityFactory entityFactory)
    {
      _entityFactory = entityFactory;
    }

    public void Initialize()
    {
      _entityFactory.Create<InputEntity>()
        .isInput = true;
    }
  }
}