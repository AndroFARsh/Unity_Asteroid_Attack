using Code.Infrastructure.Progress.Data;

namespace Code.Infrastructure.Progress
{
  public interface IProgressDataProvider
  {
    ProgressData ProgressData { get; }
  }
}