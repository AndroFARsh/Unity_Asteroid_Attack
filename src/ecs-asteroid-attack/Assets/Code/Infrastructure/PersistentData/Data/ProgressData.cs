using System;

namespace Code.Infrastructure.PersistentData.Data
{
  [Serializable]
  public class ProgressData
  {
    public int Score;
    
    public int MaxScore;
    
    public int PrevScore;
    
    public int LastUnlockedLevel;
  }
}