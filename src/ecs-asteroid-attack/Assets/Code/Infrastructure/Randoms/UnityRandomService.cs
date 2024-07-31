namespace Code.Infrastructure.Randoms
{
	public class UnityRandomService : IRandomService
  {
  	public float Range(float inclusiveMin, float exclusiveMax) => 
		  UnityEngine.Random.Range(inclusiveMin, exclusiveMax);
    
		public int Range(int inclusiveMin, int exclusiveMax) => 
			UnityEngine.Random.Range(inclusiveMin, exclusiveMax);
  }
}