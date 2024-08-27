using Code.Common.View.UI;
using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Project;
using Code.Project.States;

namespace Code.Home.UI.MainMenu
{
  public class MainMenuUIPresenter : IUIViewPresenter<MainMenuUIView>
  {
    private readonly IStateMachine _stateMachine;
    private readonly IWindowService _windowService;

    public MainMenuUIPresenter(IStateMachine stateMachine, IWindowService windowService)
    {
      _stateMachine = stateMachine;
      _windowService = windowService;
    }
    
    public void OnAttach(MainMenuUIView view)
    {
      view.Title.text = ProjectConst.ProjectName;
      view.Version.text = ProjectConst.ProjectVersion;
      view.Play.onClick.AddListener(OnPlayClicked);
      view.Settings.onClick.AddListener(OnSettingsClicked);
      view.Credits.onClick.AddListener(OnCreditsClicked);
    }

    public void OnDetach(MainMenuUIView view) => 
      view.Play.onClick.RemoveListener(OnPlayClicked);

    private void OnPlayClicked() => _stateMachine.Enter<LoadLevelsState>();
    
    private void OnCreditsClicked() => _stateMachine.Enter<LoadCreditsState>();
    
    private void OnSettingsClicked() => _windowService.Push(WindowName.SettingsWindow);
  }
}