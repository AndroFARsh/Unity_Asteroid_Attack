using UnityEngine;

namespace Code.Infrastructure.Sounds.Factories
{
  public interface ISoundSourceFactory
  {
    AudioSource PeekOrCreate();
    
    void Release(AudioSource source);
  }
}