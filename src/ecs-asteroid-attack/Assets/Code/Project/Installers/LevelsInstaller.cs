using Code.Infrastructure.LifetimeScope.Installers;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using Code.Levels.UI.LevelsMenu;
using VContainer;

namespace Code.Project.Installers
{
  public class LevelsInstaller : MonoBehaviourInstaller
  {
    public override void Install(IContainerBuilder builder)
    {
      RegisterUIViewServices(builder);
      RegisterUIFactories(builder);
    }

    private void RegisterUIFactories(IContainerBuilder builder)
    {
      builder.Register<LevelButtonFactory>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterUIViewServices(IContainerBuilder builder)
    {
      builder.Register<LevelsMenuUIService>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<LevelButtonUIService>(Lifetime.Singleton).AsImplementedInterfaces();
    }
  }
}