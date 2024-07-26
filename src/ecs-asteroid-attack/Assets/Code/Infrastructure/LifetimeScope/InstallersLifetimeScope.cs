using Code.Infrastructure.LifetimeScope.Installers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.LifetimeScope
{
  public class InstallersLifetimeScope : VContainer.Unity.LifetimeScope
  {
    [SerializeField] private MonoBehaviourInstaller[] _installers;

    protected override void Configure(IContainerBuilder builder)
    {
      foreach (IInstaller installer in _installers)
        installer?.Install(builder);
    }
  }
}