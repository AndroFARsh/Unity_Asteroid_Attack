using Code.Common.View.UI;
using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Project;
using Code.Project.States;

namespace Code.Home.UI.MainMenu
{
  public class MainMenuUIPresenter : IUIViewPresenter<MainMenuUIView>
  {
    private readonly IStateMachine _stateMachine;

    public MainMenuUIPresenter(IStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(MainMenuUIView view)
    {
      view.Title.text = ProjectConst.ProjectName;
      view.Version.text = ProjectConst.ProjectVersion;
      view.Play.onClick.AddListener(OnPlayClicked);
    }

    public void OnDetach(MainMenuUIView view) => 
      view.Play.onClick.RemoveListener(OnPlayClicked);

    private void OnPlayClicked() => _stateMachine.Enter<LoadLevelsState>();
  }
}