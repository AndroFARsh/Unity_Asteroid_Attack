//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherExplosive;

    public static Entitas.IMatcher<GameEntity> Explosive {
        get {
            if (_matcherExplosive == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Explosive);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherExplosive = matcher;
            }

            return _matcherExplosive;
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

    static readonly Code.Game.Explosions.ExplosiveComponent explosiveComponent = new Code.Game.Explosions.ExplosiveComponent();

    public bool isExplosive {
        get { return HasComponent(GameComponentsLookup.Explosive); }
        set {
            if (value != isExplosive) {
                var index = GameComponentsLookup.Explosive;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : explosiveComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}