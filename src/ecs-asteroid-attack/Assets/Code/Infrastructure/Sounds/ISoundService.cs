namespace Code.Infrastructure.Sounds
{
  public interface ISoundService
  {
    float MusicVolume { get; set; }
    float FxVolume { get; set; }
    bool PlayMusic(MusicName name);
    bool StopMusic(MusicName name);
    void PlayFx(FxName name);
  }
}