using Code.Infrastructure.LifetimeScope.Installers;
using Code.Project.EntryPoint;
using VContainer;

namespace Code.Project.Installers
{
  public class BootstrapInstaller : MonoBehaviourInstaller
  {
    public override void Install(IContainerBuilder builder)
    {
      RegisterEntryPoint(builder);
    }

    private static void RegisterEntryPoint(IContainerBuilder builder)
    {
      builder.Register<ProjectEntryPoint>(Lifetime.Singleton).AsImplementedInterfaces();
    }
  }
}