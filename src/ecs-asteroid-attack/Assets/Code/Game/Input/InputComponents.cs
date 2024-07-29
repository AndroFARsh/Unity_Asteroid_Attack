using Entitas;

namespace Code.Game.Input
{
  [Input] public class InputComponent : IComponent { }
  
  [Input] public class RotationComponent : IComponent { public float Value; }
  
  [Input] public class AccelerationComponent : IComponent { public float Value; }
  
  [Input] public class FireComponent : IComponent { }
}