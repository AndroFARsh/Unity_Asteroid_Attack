using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;

namespace Code.Home.Windows.Settings
{
  public class SettingsWindowPresenter : IUIViewPresenter<SettingsWindow>
  {
    private readonly IWindowService _windowService;
    
    public SettingsWindowPresenter(
      IWindowService windowService
    )
    {
      _windowService = windowService;
    }

    public void OnAttach(SettingsWindow view)
    {
      view.Save.onClick.AddListener(OnSaveClick);
      view.Back.onClick.AddListener(OnBackClick); 
    }

    public void OnDetach(SettingsWindow view)
    {
      view.Save.onClick.RemoveListener(OnSaveClick);
      view.Back.onClick.RemoveListener(OnBackClick);
    }

    private void OnBackClick() => _windowService.Pop();

    private void OnSaveClick()
    {
      _windowService.Pop();
      // todo: save settings;
    }
  }
}