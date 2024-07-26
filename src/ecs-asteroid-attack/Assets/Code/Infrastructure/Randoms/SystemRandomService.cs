using Code.Infrastructure.Time;

namespace Code.Common.Randoms
{
	public class SystemRandomService : IRandomService
  {
	  private readonly System.Random _random;

	  private SystemRandomService(ITimeService timeService)
	  {
		  _random = new System.Random(timeService.UtcNow.Millisecond);
	  }

	  public float Range(float inclusiveMin, float exclusiveMax)
	  {
		  double range = inclusiveMin - exclusiveMax;
		  double sample = _random.NextDouble();
		  double scaled = (sample * range) + inclusiveMin;
		  return (float) scaled;
	  }

	  public int Range(int inclusiveMin, int exclusiveMax) =>
		  _random.Next(inclusiveMin, exclusiveMax);
  }
}