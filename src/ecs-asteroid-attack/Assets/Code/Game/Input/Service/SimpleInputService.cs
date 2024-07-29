namespace Code.Game.Input.Service
{
  public class SimpleInputService : IInputService
  {
    public bool HasHorizontalAxisInput() => GetHorizontalAxis() != 0;
    
    public bool HasVerticalAxisInput() => GetVerticalAxis() != 0;
    
    public float GetVerticalAxis() => UnityEngine.Input.GetAxis("Vertical");
    public float GetHorizontalAxis() => UnityEngine.Input.GetAxis("Horizontal");

    public bool IsFireButtonPressed() => UnityEngine.Input.GetButton("Jump");

  }
}