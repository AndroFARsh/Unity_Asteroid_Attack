//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHostileSpawner;

    public static Entitas.IMatcher<GameEntity> HostileSpawner {
        get {
            if (_matcherHostileSpawner == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HostileSpawner);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHostileSpawner = matcher;
            }

            return _matcherHostileSpawner;
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

    static readonly Code.Game.HostileSpawners.HostileSpawnerComponent hostileSpawnerComponent = new Code.Game.HostileSpawners.HostileSpawnerComponent();

    public bool isHostileSpawner {
        get { return HasComponent(GameComponentsLookup.HostileSpawner); }
        set {
            if (value != isHostileSpawner) {
                var index = GameComponentsLookup.HostileSpawner;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : hostileSpawnerComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}