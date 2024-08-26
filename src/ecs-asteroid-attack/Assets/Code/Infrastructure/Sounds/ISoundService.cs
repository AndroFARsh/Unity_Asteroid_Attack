namespace Code.Infrastructure.Sounds
{
  public interface ISoundService
  {
    float MusicVolume { get; set; }
    float FxVolume { get; set; }
    void PlayMusic(MusicName name);
    void StopMusic(MusicName name);
    void PlayFx(FxName name);
  }
}