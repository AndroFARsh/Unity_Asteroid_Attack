//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentScore;

    public static Entitas.IMatcher<GameEntity> CurrentScore {
        get {
            if (_matcherCurrentScore == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentScore);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentScore = matcher;
            }

            return _matcherCurrentScore;
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

    public Code.Game.Level.CurrentScoreComponent currentScore { get { return (Code.Game.Level.CurrentScoreComponent)GetComponent(GameComponentsLookup.CurrentScore); } }
    public int CurrentScore { get { return currentScore.Value; } }
    public bool hasCurrentScore { get { return HasComponent(GameComponentsLookup.CurrentScore); } }

    public GameEntity AddCurrentScore(int newValue) {
        var index = GameComponentsLookup.CurrentScore;
        var component = (Code.Game.Level.CurrentScoreComponent)CreateComponent(index, typeof(Code.Game.Level.CurrentScoreComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCurrentScore(int newValue) {
        var index = GameComponentsLookup.CurrentScore;
        var component = (Code.Game.Level.CurrentScoreComponent)CreateComponent(index, typeof(Code.Game.Level.CurrentScoreComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCurrentScore() {
        RemoveComponent(GameComponentsLookup.CurrentScore);
        return this;
    }
}
