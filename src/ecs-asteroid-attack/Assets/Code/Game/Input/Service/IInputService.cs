namespace Code.Game.Input.Service
{
  public interface IInputService
  {
    float GetVerticalAxis();
    float GetHorizontalAxis();

    bool HasVerticalAxisInput();
    
    bool HasHorizontalAxisInput();

    bool IsFireButtonPressed();
  }
}