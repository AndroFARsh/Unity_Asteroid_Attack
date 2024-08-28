using Code.Common.Curtains;
using Code.Common.View.Factories;
using Code.Credits.UI.Credits;
using Code.Game.Abilities.Factories;
using Code.Game.Armaments.Factories;
using Code.Game.Cameras.Services;
using Code.Game.Explosions.Factories;
using Code.Game.Hostiles.Factories;
using Code.Game.HUD;
using Code.Game.HUD.Services;
using Code.Game.Input.Service;
using Code.Game.Level.Factories;
using Code.Game.Player.Factories;
using Code.Game.Windows.GameOver;
using Code.Game.Windows.Pause;
using Code.Game.Windows.Win;
using Code.Home.UI.MainMenu;
using Code.Home.Windows.Services;
using Code.Home.Windows.Settings;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Instantioator;
using Code.Infrastructure.LifetimeScope.Installers;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.PersistentData.SaveLoad;
using Code.Infrastructure.Physics;
using Code.Infrastructure.Randoms;
using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.Sounds;
using Code.Infrastructure.Sounds.Factories;
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

      RegisterCommonServices(builder);
      RegisterFactories(builder);

      RegisterStateMachine(builder);

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

    private static void RegisterStateMachine(IContainerBuilder builder)
    {
      builder.Register<StateResolver>(Lifetime.Singleton).As<IStateResolver>();
      builder.Register<StateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterCommonServices(IContainerBuilder builder)
    {
      builder.Register<StaticDataService>(Lifetime.Singleton).As<IStaticDataService>();
      
      builder.Register<PersistentDataProvider>(Lifetime.Singleton).As<IPersistentDataProvider>().AsSelf();
      builder.Register<SaveLoadService>(Lifetime.Singleton).As<ISaveLoadService>().AsSelf();
      
      builder.Register<IdProvider>(Lifetime.Singleton).As<IIdProvider>();
      builder.Register<UnityTimeService>(Lifetime.Singleton).As<ITimeService>();
      builder.Register<UnityRandomService>(Lifetime.Singleton).As<IRandomService>();

      builder.Register<SoundService>(Lifetime.Singleton).As<ISoundService>();
      builder.Register<UnityResourcesAssetProvider>(Lifetime.Singleton).As<IAssetProvider>();
      builder.Register<UnitySceneLoader>(Lifetime.Singleton).As<ISceneLoader>();

      builder.Register<ColliderToEntityRegistryResolver>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<UnityPhysicsService>(Lifetime.Singleton).As<IPhysicsService>();

      builder.Register<WindowService>(Lifetime.Singleton).As<IWindowService>();
    }

    private static void RegisterFactories(IContainerBuilder builder)
    {
      builder.Register<SoundSourceFactory>(Lifetime.Singleton).As<ISoundSourceFactory>();
      builder.Register<EntityViewPool>(Lifetime.Singleton).As<IEntityViewPool>();
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
      builder.Register<MainMenuUIPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      
      builder.Register<LevelsMenuUIPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<LevelButtonUIPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      
      builder.Register<CreditsUIPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      
      builder.Register<GameHUDPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<PauseWindowPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<GameOverWindowPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<WinWindowPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<SettingsWindowPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterUIViewServices(IContainerBuilder builder)
    {
      builder.Register<GameHUDService>(Lifetime.Singleton).AsImplementedInterfaces();
      builder.Register<SettingsUIService>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private static void RegisterGameplayServices(IContainerBuilder builder)
    {
      builder.Register<SimpleInputService>(Lifetime.Singleton).As<IInputService>();
      builder.Register<CameraProvider>(Lifetime.Singleton).As<ICameraProvider>();
      builder.Register<LevelDataProvider>(Lifetime.Singleton).As<ILevelDataProvider>();
    }

    private static void RegisterGameplayFactories(IContainerBuilder builder)
    {
      builder.Register<LevelInfoFactory>(Lifetime.Singleton).As<ILevelInfoFactory>();
      builder.Register<PlayerFactory>(Lifetime.Singleton).As<IPlayerFactory>();
      builder.Register<HostileFactory>(Lifetime.Singleton).As<IHostileFactory>();
      builder.Register<AbilityFactory>(Lifetime.Singleton).As<IAbilityFactory>();
      builder.Register<ArmamentFactory>(Lifetime.Singleton).As<IArmamentFactory>();
      builder.Register<ExplosionFactory>(Lifetime.Singleton).As<IExplosionFactory>();
    }
  }
}