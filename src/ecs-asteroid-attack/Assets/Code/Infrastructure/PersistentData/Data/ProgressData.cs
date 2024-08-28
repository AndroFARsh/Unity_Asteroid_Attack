using System;

namespace Code.Infrastructure.PersistentData.Data
{
  [Serializable]
  public class ProgressData
  {
    public int LastScore;
    
    public int CurrentScore;

    public int LastUnlockedLevel;
  }
}