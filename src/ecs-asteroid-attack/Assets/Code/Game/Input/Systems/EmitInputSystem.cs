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
          input.ReplaceThrottle(_inputService.GetVerticalAxis());
        else if (input.hasThrottle)
          input.RemoveThrottle();
        
        if (_inputService.HasHorizontalAxisInput())
          input.ReplaceYaw(-_inputService.GetHorizontalAxis());
        else if (input.hasYaw)
          input.RemoveYaw();

        input.isFire = _inputService.IsFireButtonPressed();
      }
    }
  }
}