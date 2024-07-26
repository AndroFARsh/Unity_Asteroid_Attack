using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Code.Infrastructure
{
  // Has execution order to start before every other script
  [DefaultExecutionOrder(-32000)]
  public class SwitchToEntrySceneInEditor : MonoBehaviour
  {
#if UNITY_EDITOR
    private const int EntrySceneIndex = 0;

    private void Awake()
    {
      if (HasRootContainer()) return;
      
      foreach (GameObject root in gameObject.scene.GetRootGameObjects()) 
        root.SetActive(false);
      
      SceneManager.LoadScene(EntrySceneIndex);
    }

    private static bool HasRootContainer()
    {
      FieldInfo field = typeof(VContainerSettings).GetField("rootLifetimeScopeInstance", BindingFlags.NonPublic | BindingFlags.Static);
      object result = field?.GetValue(null);
      return result != null;
    }
    
#endif
  }
}