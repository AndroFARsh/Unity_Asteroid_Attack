using Entitas;

namespace Code.Game.Input
{
  [Input] public class InputComponent : IComponent { }
  
  [Input] public class YawComponent : IComponent { public float Value; }
  
  [Input] public class ThrottleComponent : IComponent { public float Value; }
  
  [Input] public class FireComponent : IComponent { }
}