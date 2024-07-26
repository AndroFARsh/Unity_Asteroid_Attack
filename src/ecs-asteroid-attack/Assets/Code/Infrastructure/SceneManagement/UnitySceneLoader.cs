using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.SceneManagement
{
  public class UnitySceneLoader : ISceneLoader
  {
    public async void LoadScene(string name, Action onLoaded)
    {
      await LoadSceneAsync(name);
      onLoaded?.Invoke();
    } 
    
    public UniTask LoadSceneAsync(string name)
    {
      if (SceneManager.GetActiveScene().name == name)
        return UniTask.CompletedTask;
      
      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
      
      return asyncOperation?.ToUniTask() ?? UniTask.CompletedTask;
    }
  }
}