using Code.Infrastructure.WindowManagement;
using Code.Infrastructure.WindowManagement.Configs;

namespace Code.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    
    WindowConfig GetWindowConfig(WindowName name);
  }
}