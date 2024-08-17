//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAbilityName;

    public static Entitas.IMatcher<GameEntity> AbilityName {
        get {
            if (_matcherAbilityName == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AbilityName);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAbilityName = matcher;
            }

            return _matcherAbilityName;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Game.Abilities.AbilityNameComponent abilityName { get { return (Code.Game.Abilities.AbilityNameComponent)GetComponent(GameComponentsLookup.AbilityName); } }
    public Code.Game.Abilities.AbilityName AbilityName { get { return abilityName.Value; } }
    public bool hasAbilityName { get { return HasComponent(GameComponentsLookup.AbilityName); } }

    public GameEntity AddAbilityName(Code.Game.Abilities.AbilityName newValue) {
        var index = GameComponentsLookup.AbilityName;
        var component = (Code.Game.Abilities.AbilityNameComponent)CreateComponent(index, typeof(Code.Game.Abilities.AbilityNameComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAbilityName(Code.Game.Abilities.AbilityName newValue) {
        var index = GameComponentsLookup.AbilityName;
        var component = (Code.Game.Abilities.AbilityNameComponent)CreateComponent(index, typeof(Code.Game.Abilities.AbilityNameComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAbilityName() {
        RemoveComponent(GameComponentsLookup.AbilityName);
        return this;
    }
}
