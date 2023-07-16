namespace DependencyInjection
{
    public class NumGenerator : INumGenerator
    {
        public int RandomValue { get; }
        public NumGenerator()
        {
            RandomValue = new Random().Next(1000);
        }

        //public int GetRandomNumber()
        //{
        //    return new Random().Next(1000); 
        //}

    }
    public interface INumGenerator
    {
        int RandomValue { get; }    
        //int GetRandomNumber();
    }
}
