using Code.Game.Level.Factories;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class InitLevelSystem : IInitializeSystem 
  {
    private readonly ILevelInfoFactory _factory;
    
    private InitLevelSystem(ILevelInfoFactory factory)
    {
      _factory = factory;
    }

    public void Initialize() => _factory.CreateInfo();
  }
}