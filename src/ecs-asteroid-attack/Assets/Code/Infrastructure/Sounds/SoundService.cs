using System.Collections.Generic;
using Code.Infrastructure.Sounds.Factories;
using Code.Infrastructure.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Sounds
{
  public class SoundService : ISoundService
  {
    private readonly Dictionary<MusicName, AudioSource> _playedMusicSource = new();
    
    private readonly ISoundSourceFactory _sourceFactory;
    private readonly IStaticDataService _staticDataService;

    public float MusicVolume { get; set; } = 1;

    public float FxVolume { get; set; } = 1;

    public SoundService(ISoundSourceFactory sourceFactory, IStaticDataService staticDataService)
    {
      _sourceFactory = sourceFactory;
      _staticDataService = staticDataService;
    }

    public bool PlayMusic(MusicName name)
    {
      if (_playedMusicSource.ContainsKey(name)) return false;

      AudioClip clip = _staticDataService.GetMusicClip(name);
      AudioSource source = _sourceFactory.PeekOrCreate();
      source.clip = clip;
      source.loop = true;
      source.volume = MusicVolume;
      source.Play();

      _playedMusicSource.Add(name, source);
      return true;
    }
    
    public bool StopMusic(MusicName name)
    {
      if (!_playedMusicSource.TryGetValue(name, out AudioSource source)) return false;
      
      source.Stop();
      _sourceFactory.Release(source);
      _playedMusicSource.Remove(name);
      return true;

    }
    
    public async void PlayFx(FxName name)
    {
      AudioClip clip = _staticDataService.GetFxClip(name);
      AudioSource source = _sourceFactory.PeekOrCreate();
      source.clip = clip;
      source.loop = false;
      source.volume = FxVolume;
      source.gameObject.SetActive(true);
      source.Play();
      
      await UniTask.WaitUntil(() => !source.isPlaying);
      _sourceFactory.Release(source);
    }
  }
}