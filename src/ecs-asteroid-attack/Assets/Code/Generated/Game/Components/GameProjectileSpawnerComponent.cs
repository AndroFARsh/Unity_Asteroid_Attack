//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherProjectileSpawner;

    public static Entitas.IMatcher<GameEntity> ProjectileSpawner {
        get {
            if (_matcherProjectileSpawner == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ProjectileSpawner);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherProjectileSpawner = matcher;
            }

            return _matcherProjectileSpawner;
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

    public Code.Game.Player.ProjectileSpawnerComponent projectileSpawner { get { return (Code.Game.Player.ProjectileSpawnerComponent)GetComponent(GameComponentsLookup.ProjectileSpawner); } }
    public Code.Game.Player.Behaviours.ProjectileSpawner ProjectileSpawner { get { return projectileSpawner.Value; } }
    public bool hasProjectileSpawner { get { return HasComponent(GameComponentsLookup.ProjectileSpawner); } }

    public GameEntity AddProjectileSpawner(Code.Game.Player.Behaviours.ProjectileSpawner newValue) {
        var index = GameComponentsLookup.ProjectileSpawner;
        var component = (Code.Game.Player.ProjectileSpawnerComponent)CreateComponent(index, typeof(Code.Game.Player.ProjectileSpawnerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceProjectileSpawner(Code.Game.Player.Behaviours.ProjectileSpawner newValue) {
        var index = GameComponentsLookup.ProjectileSpawner;
        var component = (Code.Game.Player.ProjectileSpawnerComponent)CreateComponent(index, typeof(Code.Game.Player.ProjectileSpawnerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveProjectileSpawner() {
        RemoveComponent(GameComponentsLookup.ProjectileSpawner);
        return this;
    }
}