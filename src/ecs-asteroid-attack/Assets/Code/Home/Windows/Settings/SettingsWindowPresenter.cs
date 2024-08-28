using Code.Home.Windows.Services;
using Code.Infrastructure.PersistentData.SaveLoad;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;

namespace Code.Home.Windows.Settings
{
  public class SettingsWindowPresenter : IUIViewPresenter<SettingsWindow>
  {
    private readonly IWindowService _windowService;
    private readonly ISettingsUIService _settingsUIService;
    private readonly ISaveLoadService _saveLoadService;

    public SettingsWindowPresenter(
      IWindowService windowService,
      ISettingsUIService settingsUIService,
      ISaveLoadService saveLoadService)
    {
      _windowService = windowService;
      _settingsUIService = settingsUIService;
      _saveLoadService = saveLoadService;
    }

    public void OnAttach(SettingsWindow view)
    {
      _settingsUIService.Initialize();

      view.MusicVolume.value = _settingsUIService.CurrentMusicVolume;
      view.MusicVolume.onValueChanged.AddListener(OnMusicVolumeChanged);

      view.EffectVolume.value = _settingsUIService.CurrentEffectVolume;
      view.EffectVolume.onValueChanged.AddListener(OnEffectVolumeChanged);
      
      view.Save.onClick.AddListener(OnSaveClick);
      view.Back.onClick.AddListener(OnBackClick); 
    }
    
    public void OnDetach(SettingsWindow view)
    {
      view.Save.onClick.RemoveListener(OnSaveClick);
      view.Back.onClick.RemoveListener(OnBackClick);
    }

    private void OnMusicVolumeChanged(float value) => _settingsUIService.UpdateMusicVolume(value);

    private void OnEffectVolumeChanged(float value) => _settingsUIService.UpdateEffectVolume(value);


    private void OnBackClick()
    {
      _windowService.Pop();
      _settingsUIService.Reset();
      _saveLoadService.SaveSettings();
    } 

    private void OnSaveClick()
    {
      _windowService.Pop();
      _settingsUIService.Apply();
      _saveLoadService.SaveSettings();
    }
  }
}