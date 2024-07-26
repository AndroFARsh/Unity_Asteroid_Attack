using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.SceneManagement
{
  public interface ISceneLoader
  {
    UniTask LoadSceneAsync(string name);
    void LoadScene(string name, Action onLoaded = null);
  }
}