//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherScore;

    public static Entitas.IMatcher<GameEntity> Score {
        get {
            if (_matcherScore == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Score);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScore = matcher;
            }

            return _matcherScore;
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

    public Code.Game.Hostiles.ScoreComponent score { get { return (Code.Game.Hostiles.ScoreComponent)GetComponent(GameComponentsLookup.Score); } }
    public int Score { get { return score.Value; } }
    public bool hasScore { get { return HasComponent(GameComponentsLookup.Score); } }

    public GameEntity AddScore(int newValue) {
        var index = GameComponentsLookup.Score;
        var component = (Code.Game.Hostiles.ScoreComponent)CreateComponent(index, typeof(Code.Game.Hostiles.ScoreComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceScore(int newValue) {
        var index = GameComponentsLookup.Score;
        var component = (Code.Game.Hostiles.ScoreComponent)CreateComponent(index, typeof(Code.Game.Hostiles.ScoreComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveScore() {
        RemoveComponent(GameComponentsLookup.Score);
        return this;
    }
}