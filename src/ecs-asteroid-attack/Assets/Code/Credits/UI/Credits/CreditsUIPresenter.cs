using Code.Infrastructure.States;
using Code.Infrastructure.UI;
using Code.Project;
using Code.Project.States;

namespace Code.Credits.UI.Credits
{
  public class CreditsUIPresenter : IUIViewPresenter<CreditsUIView>
  {
    private readonly IStateMachine _stateMachine;

    public CreditsUIPresenter(IStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(CreditsUIView view)
    {
      view.Version.text = ProjectConst.ProjectVersion;
      view.Back.onClick.AddListener(OnBackClicked);
      view.GitHub.onClick.AddListener(OnGitHubClicked);
    }

    public void OnDetach(CreditsUIView view)
    {
      view.Back.onClick.RemoveListener(OnBackClicked);
      view.GitHub.onClick.RemoveListener(OnGitHubClicked);
    }

    private void OnBackClicked() => _stateMachine.Enter<LoadHomeState>();
    
    private void OnGitHubClicked() => 
      UnityEngine.Application.OpenURL("https://github.com/AndroFARsh/Unity_Asteroid_Attack");
  }
}