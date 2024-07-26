using Code.Home.UI.MainMenu;
using Code.Infrastructure.LifetimeScope.Installers;
using VContainer;

namespace Code.Project.Installers
{
  public class HomeInstaller : MonoBehaviourInstaller
  {
    public override void Install(IContainerBuilder builder)
    {
      RegisterUIViewServices(builder);
    }

    private static void RegisterUIViewServices(IContainerBuilder builder)
    {
      builder.Register<MainMenuUIServices>(Lifetime.Singleton).AsImplementedInterfaces();
    }
  }
}