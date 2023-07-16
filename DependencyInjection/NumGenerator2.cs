using System.Reflection.Metadata.Ecma335;

namespace DependencyInjection
{
    public class NumGenerator2 : INumGenerator2
    {
        public int RandomValue { get; }
        public INumGenerator numGenerator { get; }

        public NumGenerator2(INumGenerator numGenerator)
        {
            RandomValue=new Random().Next(1000);
            this.numGenerator = numGenerator;
        }

        public int GetNumGeneratorRandomNumber()
        {
            return numGenerator.RandomValue;
        }
       
    }

    public interface INumGenerator2
    {
        int RandomValue { get; }
        int GetNumGeneratorRandomNumber();
    }
}
