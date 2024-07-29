using Code.Game.Input.Service;
using Entitas;

namespace Code.Game.Input.Systems
{
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<InputEntity> _inputs;

    public EmitInputSystem(InputContext input, IInputService inputService)
    {
      _inputService = inputService;
      _inputs = input.GetGroup(InputMatcher.Input);
    }
    
    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      {
        if (_inputService.HasVerticalAxisInput())
          input.ReplaceAcceleration(_inputService.GetVerticalAxis());
        else if (input.hasAcceleration)
          input.RemoveAcceleration();
        
        if (_inputService.HasHorizontalAxisInput())
          input.ReplaceRotation(_inputService.GetHorizontalAxis());
        else if (input.hasRotation)
          input.RemoveRotation();

        input.isFire = _inputService.IsFireButtonPressed();
      }
    }
  }
}