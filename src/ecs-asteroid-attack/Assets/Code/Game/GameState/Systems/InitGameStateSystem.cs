using Code.Game.GameState.Factories;
using Entitas;

namespace Code.Game.GameState.Systems
{
  public class InitGameStateSystem : IInitializeSystem 
  {
    private readonly IGameStateFactory _factory;
    
    private InitGameStateSystem(IGameStateFactory factory)
    {
      _factory = factory;
    }

    public void Initialize() => _factory.CreateState();
  }
}