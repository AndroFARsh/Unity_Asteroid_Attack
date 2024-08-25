//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherExplosionRun;

    public static Entitas.IMatcher<GameEntity> ExplosionRun {
        get {
            if (_matcherExplosionRun == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ExplosionRun);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherExplosionRun = matcher;
            }

            return _matcherExplosionRun;
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

    static readonly Code.Game.Explosions.ExplosionRunComponent explosionRunComponent = new Code.Game.Explosions.ExplosionRunComponent();

    public bool isExplosionRun {
        get { return HasComponent(GameComponentsLookup.ExplosionRun); }
        set {
            if (value != isExplosionRun) {
                var index = GameComponentsLookup.ExplosionRun;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : explosionRunComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}