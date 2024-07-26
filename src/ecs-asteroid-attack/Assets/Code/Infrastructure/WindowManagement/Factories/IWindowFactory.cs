using Code.Infrastructure.WindowManagement.Behaviours;
using UnityEngine;

namespace Code.Infrastructure.WindowManagement.Factories
{
  public interface IWindowFactory
  {
    IWindow CreateWindow(WindowName name, Transform parrent);
  }
}