//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherOwnerId;

    public static Entitas.IMatcher<GameEntity> OwnerId {
        get {
            if (_matcherOwnerId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OwnerId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOwnerId = matcher;
            }

            return _matcherOwnerId;
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

    public Code.Game.Abilities.OwnerIdComponent ownerId { get { return (Code.Game.Abilities.OwnerIdComponent)GetComponent(GameComponentsLookup.OwnerId); } }
    public ulong OwnerId { get { return ownerId.Value; } }
    public bool hasOwnerId { get { return HasComponent(GameComponentsLookup.OwnerId); } }

    public GameEntity AddOwnerId(ulong newValue) {
        var index = GameComponentsLookup.OwnerId;
        var component = (Code.Game.Abilities.OwnerIdComponent)CreateComponent(index, typeof(Code.Game.Abilities.OwnerIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceOwnerId(ulong newValue) {
        var index = GameComponentsLookup.OwnerId;
        var component = (Code.Game.Abilities.OwnerIdComponent)CreateComponent(index, typeof(Code.Game.Abilities.OwnerIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveOwnerId() {
        RemoveComponent(GameComponentsLookup.OwnerId);
        return this;
    }
}
