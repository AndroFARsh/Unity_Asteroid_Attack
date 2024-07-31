using Code.Common.Curtains;
using Code.Common.EntityFactories;
using Code.Common.Physics;
using Code.Common.View.Factories;
using Code.Game.Cameras.Services;
using Code.Game.Hostiles.Factories;
using Code.Game.HUD;
using Code.Game.HUD.Services;
using Code.Game.Input.Service;
using Code.Game.Player.Factories;
using Code.Game.Windows.Pause;
using Code.Home.UI.MainMenu;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Instantioator;
using Code.Infrastructure.LifetimeScope.Installers;
using Code.Infrastructure.Progress;
using Code.Infrastructure.Randoms;
using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Resolvers;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.Systems;
using Code.Infrastructure.Time;
using Code.Infrastructure.Windows.Factories;
using Code.Infrastructure.Windows.Services;
using Code.Levels.Services;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using Code.Levels.UI.LevelsMenu;
using Code.Project.States;
using VContainer;
using VContainer.Unity;

namespace Code.Project.Installers
{
  public class ProjectInstaller : MonoBehaviourInstaller
  {
    public override void Install(IContainerBuilder builder)
    {
      RegisterContexts(builder);
      RegisterCurtain(builder);

      RegisterStaticData(builder);
      RegisterProgressData(builder);

      RegisterCommonServices(builder);
      RegisterFactories(builder);

      RegisterStateMachine(builder);
      RegisterStates(builder);

      RegisterUIViewPresenters(builder);
      RegisterUIViewServices(builder);
      RegisterUIFactories(builder);

      RegisterGameplayServices(builder);
      RegisterGameplayFactories(builder);
    }
    
    private static void RegisterContexts(IContainerBuilder builder)
    {
      builder.RegisterInstance(Contexts.sharedInstance.game);
      builder.RegisterInstance(Contexts.sharedInstance.input);
      builder.RegisterInstance(Contexts.sharedInstance.meta);
    }

    private static void RegisterCurtain(IContainerBuilder builder)
    {
      builder.RegisterComponentInNewPrefab(CurtainPrefabResolver.Resolver, Lifetime.Singleton)
        .DontDestroyOnLoad()
        .As<ICurtainService>();
    }

    private static void RegisterProgressData(IContainerBuilder builder)
    {
      builder.Register<ProgressDataProvider>(Lifetime.Singleton).As<IProgressDataProvider>().AsSelf();
    }

    private static void RegisterStaticData(IContainerBuilder builder)
    {
      builder.Register<StaticDataService>(Lifetime.Singleton).As<IStaticDataService>();
    }

    private static void RegisterStateMachine(IContainerBuilder builder)
    {
      builder.Register<StateResolver>(Lifetime.Singleton).As<IStateResolver>();
      builder.Register<StateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterStates(IContainerBuilder builder)
    {
      builder.Register<BootstrapState>(Lifetime.Singleton).AsSelf();
      builder.Register<LoadHomeState>(Lifetime.Singleton).AsSelf();
      builder.Register<HomeState>(Lifetime.Singleton).AsSelf();
      builder.Register<LoadLevelsState>(Lifetime.Singleton).AsSelf();
      builder.Register<LevelsState>(Lifetime.Singleton).AsSelf();
      builder.Register<LoadGameState>(Lifetime.Singleton).AsSelf();
      builder.Register<GameState>(Lifetime.Singleton).AsSelf();
    }

    private static void RegisterCommonServices(IContainerBuilder builder)
    {
      builder.Register<IdProvider>(Lifetime.Singleton).As<IIdProvider>();
      builder.Register<UnityTimeService>(Lifetime.Singleton).As<ITimeService>();
      builder.Register<UnityRandomService>(Lifetime.Singleton).As<IRandomService>();

      builder.Register<UnityResourcesAssetProvider>(Lifetime.Singleton).As<IAssetProvider>();
      builder.Register<UnitySceneLoader>(Lifetime.Singleton).As<ISceneLoader>();

      builder.Register<ColliderToEntityRegistryResolver>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<UnityPhysicsService>(Lifetime.Singleton).As<IPhysicsService>();

      builder.Register<WindowService>(Lifetime.Singleton).As<IWindowService>();
    }

    private static void RegisterFactories(IContainerBuilder builder)
    {
      builder.Register<Instantiator>(Lifetime.Singleton).As<IInstantiator>();
      builder.Register<EntityViewFactory>(Lifetime.Singleton).As<IEntityViewFactory>();
      builder.Register<SystemFactory>(Lifetime.Singleton).As<ISystemFactory>();
      builder.Register<EntityFactory>(Lifetime.Singleton).As<IEntityFactory>();
      builder.Register<WindowFactory>(Lifetime.Singleton).As<IWindowFactory>();
    }
    
    private static void RegisterUIFactories(IContainerBuilder builder)
    {
      builder.Register<LevelButtonFactory>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterUIViewPresenters(IContainerBuilder builder)
    {
      builder.Register<MainMenuIuiPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      
      builder.Register<LevelsMenuIuiPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<LevelButtonIuiPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      
      builder.Register<GameHUDPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<PauseWindowPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterUIViewServices(IContainerBuilder builder)
    {
      builder.Register<GameHUDService>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterGameplayServices(IContainerBuilder builder)
    {
      builder.Register<SimpleInputService>(Lifetime.Singleton).As<IInputService>();
      builder.Register<CameraProvider>(Lifetime.Singleton).As<ICameraProvider>();
      builder.Register<LevelDataProvider>(Lifetime.Singleton).As<ILevelDataProvider>();
    }

    private static void RegisterGameplayFactories(IContainerBuilder builder)
    {
      builder.Register<PlayerFactory>(Lifetime.Singleton).As<IPlayerFactory>();
      builder.Register<HostileFactory>(Lifetime.Singleton).As<IHostileFactory>();
    }
  }
}