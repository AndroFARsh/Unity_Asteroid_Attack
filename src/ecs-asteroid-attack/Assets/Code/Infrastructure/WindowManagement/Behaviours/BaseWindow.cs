using System;
using UnityEngine;

namespace Code.Infrastructure.WindowManagement.Behaviours
{
  public abstract class BaseWindow : MonoBehaviour, IWindow
  {
    // This method would be called right after window created 
    protected virtual void OnInitialize()
    {
    }

    // This method would be called right before window would be shown
    protected virtual void OnResume()
    {
    }

    // This method would be called right after window would be hidden
    protected virtual void OnPause()
    {
    }

    // This method would be called right before destruction
    protected virtual void OnCleanup()
    {
    }

    private void Awake() => OnInitialize();

    private void OnDestroy() => OnCleanup();
    
    void IWindow.Resume()
    {
      OnResume();
      gameObject.SetActive(true);
    }

    void IWindow.Pause()
    {
      gameObject.SetActive(false);
      OnPause();
    }
  }
}