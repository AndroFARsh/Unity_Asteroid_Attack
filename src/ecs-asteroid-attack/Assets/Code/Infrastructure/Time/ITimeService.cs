using System;

namespace Code.Infrastructure.Time
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    DateTime UtcNow { get; }
    void StopTime();
    void StartTime();
  }
}