using Code.Infrastructure.Time;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class ResetTimeServiceSystem : ITearDownSystem 
  {
    private readonly ITimeService _timeService;

    private ResetTimeServiceSystem(ITimeService timeService)
    {
      _timeService = timeService;
    }

    public void TearDown() => _timeService.Resume();
  }
}