using Code.Infrastructure.Sounds;
using Entitas;

namespace Code.Home.Systems
{
  public class PlayMenuBackgroundMusicSystem : IInitializeSystem, ITearDownSystem 
  {
    private readonly ISoundService _soundService;

    private PlayMenuBackgroundMusicSystem(ISoundService soundService)
    {
      _soundService = soundService;
    }

    public void Initialize() => _soundService.PlayMusic(MusicName.Home);
    
    public void TearDown() => _soundService.StopMusic(MusicName.Home);
  }
}