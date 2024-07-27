using System.Collections.Generic;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Factories;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.Windows.Services
{
  public class WindowService : IWindowService
  {
    private readonly IWindowFactory _windowFactory;
    
    private readonly Stack<WindowName> _stack = new();
    private readonly Dictionary<WindowName, IWindow> _windows = new();

    private IWindowRoot _windowRoot;
    
    WindowService(IWindowFactory windowFactory)
    {
      _windowFactory = windowFactory;
    }

    public void Retain(IWindowRoot windowRoot)
    {
      _windowRoot = windowRoot;
      _windows.Clear();
    }

    public void Push(WindowName name, int flag = 0)
    {
      if (_stack.TryPeek(out WindowName prevName))
      {
        IWindow prevWindow = GetOrCreateWindow(prevName);
        prevWindow.Pause();
      }

      if ((flag | IWindowService.REPLACE_TOP_FLAG) > 0) _stack.TryPop(out WindowName _);
      if ((flag | IWindowService.CLEAR_STACK_FLAG) > 0) _stack.Clear();

      IWindow window = GetOrCreateWindow(name);
      window.Resume();
      
      _stack.Push(name);
      
      if (_stack.Count >= 0) _windowRoot.Show().Forget();
    }

    public void Pop()
    {
      if (_stack.TryPop(out WindowName name))
      {
        IWindow window = GetOrCreateWindow(name);
        window.Pause();
      }

      if (_stack.Count == 0) _windowRoot.Hide().Forget();
    }
    
    public void Release()
    {
      _windowRoot.Hide();
      _windowRoot = null;
      _windows.Clear();
    }

    private IWindow GetOrCreateWindow(WindowName name)
    {
      if (_windows.TryGetValue(name, out IWindow window))
        return window;

      window = _windowFactory.CreateWindow(name, _windowRoot.Transform);
      
      _windows.Add(name, window);
      return window;
    }
  }
}