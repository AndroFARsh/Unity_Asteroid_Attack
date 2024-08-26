using Code.Infrastructure.Sounds;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class PlayBackgroundMusicSystem : IInitializeSystem, ITearDownSystem 
  {
    private readonly ISoundService _soundService;

    private PlayBackgroundMusicSystem(ISoundService soundService)
    {
      _soundService = soundService;
    }

    public void Initialize() => _soundService.PlayMusic(MusicName.Gameplay);
    
    public void TearDown() => _soundService.StopMusic(MusicName.Gameplay);
  }
}