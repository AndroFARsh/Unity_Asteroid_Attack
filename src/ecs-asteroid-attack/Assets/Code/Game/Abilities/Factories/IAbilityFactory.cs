namespace Code.Game.Abilities.Factories
{
  public interface IAbilityFactory
  {
    GameEntity CreateAbility(AbilityName name, ulong ownerId);
  }
}