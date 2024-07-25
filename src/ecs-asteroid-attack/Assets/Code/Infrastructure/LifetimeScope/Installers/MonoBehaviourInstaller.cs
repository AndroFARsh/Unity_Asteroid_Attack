using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.LifetimeScope.Installers
{
  public abstract class MonoBehaviourInstaller : MonoBehaviour, IInstaller
  {
    public abstract void Install(IContainerBuilder builder);
  }
}