using UnityEngine;

namespace Code.Infrastructure.Windows.Factories
{
  public interface IWindowFactory
  {
    IWindow CreateWindow(WindowName name, Transform parrent);
  }
}