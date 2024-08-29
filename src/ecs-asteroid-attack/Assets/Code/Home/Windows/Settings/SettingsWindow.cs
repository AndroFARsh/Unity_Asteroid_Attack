using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Home.Windows.Settings
{
  public class SettingsWindow : BaseWindow
  {
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectSlider;
    [SerializeField] private Button _resetProgressButton;
    
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _saveButton;
    
    private IUIViewPresenter<SettingsWindow> _viewPresenter;

    public Slider MusicVolume => _musicSlider;
    public Slider EffectVolume => _effectSlider;
    public Button ResetProgress => _resetProgressButton;
    public Button Back => _backButton;
    public Button Save => _saveButton;
    
    [Inject]
    public void Construct(IUIViewPresenter<SettingsWindow> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    protected override void OnResume() => _viewPresenter.OnAttach(this);

    protected override void OnPause() => _viewPresenter.OnDetach(this);
  }
}