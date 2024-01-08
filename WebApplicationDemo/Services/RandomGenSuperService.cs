namespace WebApplicationDemo.Services
{
    //CLASS EXEMPLE NON UTILISEE
    public class RandomGenSuperService : IRandomGenService
    {
        public int GetRandom(int min, int max)
        {
            int rnd = new Random().Next(min, max);
            rnd += 500;
            return rnd;
        }
    }
}
