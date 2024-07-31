namespace Code.Game.Hostiles.Factories
{
  public interface IHostileFactory
  {
    GameEntity CreateHostile(HostileName name);
  }
}