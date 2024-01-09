namespace WebApplicationDemo.Services
{
    public class RandomGenService : IRandomGenService
    {
        public int GetRandom(int min, int max)
        {
            return Random.Shared.Next(min,max);
        }
    }
}