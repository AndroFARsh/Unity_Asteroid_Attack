using Code.Infrastructure.Sounds;
using Entitas;

namespace Code.Levels.Systems
{
  public class PlayBackgroundMusicSystem : IInitializeSystem, ITearDownSystem 
  {
    private readonly ISoundService _soundService;

    private PlayBackgroundMusicSystem(ISoundService soundService)
    {
      _soundService = soundService;
    }

    public void Initialize() => _soundService.PlayMusic(MusicName.Home);
    
    public void TearDown() => _soundService.StopMusic(MusicName.Home);
  }
}