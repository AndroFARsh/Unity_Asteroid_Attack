using Code.Infrastructure.Progress.Data;

namespace Code.Infrastructure.Progress
{
  public class ProgressDataProvider : IProgressDataProvider
  {
    public ProgressData ProgressData { get; private set; }

    public void SetProgressData(ProgressData data)
    {
      ProgressData = data;
    }
  }
}