//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHostileSpawnerTimer;

    public static Entitas.IMatcher<GameEntity> HostileSpawnerTimer {
        get {
            if (_matcherHostileSpawnerTimer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HostileSpawnerTimer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHostileSpawnerTimer = matcher;
            }

            return _matcherHostileSpawnerTimer;
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

    public Code.Game.HostileSpawners.HostileSpawnerTimerComponent hostileSpawnerTimer { get { return (Code.Game.HostileSpawners.HostileSpawnerTimerComponent)GetComponent(GameComponentsLookup.HostileSpawnerTimer); } }
    public float HostileSpawnerTimer { get { return hostileSpawnerTimer.Value; } }
    public bool hasHostileSpawnerTimer { get { return HasComponent(GameComponentsLookup.HostileSpawnerTimer); } }

    public GameEntity AddHostileSpawnerTimer(float newValue) {
        var index = GameComponentsLookup.HostileSpawnerTimer;
        var component = (Code.Game.HostileSpawners.HostileSpawnerTimerComponent)CreateComponent(index, typeof(Code.Game.HostileSpawners.HostileSpawnerTimerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHostileSpawnerTimer(float newValue) {
        var index = GameComponentsLookup.HostileSpawnerTimer;
        var component = (Code.Game.HostileSpawners.HostileSpawnerTimerComponent)CreateComponent(index, typeof(Code.Game.HostileSpawners.HostileSpawnerTimerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHostileSpawnerTimer() {
        RemoveComponent(GameComponentsLookup.HostileSpawnerTimer);
        return this;
    }
}
