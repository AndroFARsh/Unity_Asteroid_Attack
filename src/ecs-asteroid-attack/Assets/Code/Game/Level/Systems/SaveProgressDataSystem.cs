using Code.Infrastructure.PersistentData.SaveLoad;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class SaveProgressDataSystem : ITearDownSystem 
  {
    private readonly ISaveLoadService _saveLoadService;


    private SaveProgressDataSystem(ISaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
    }

    public void TearDown() => _saveLoadService.SaveProgress();
  }
}