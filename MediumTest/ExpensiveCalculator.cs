using System.Threading;

namespace MediumTest
{
    public class ExpensiveCalculator
    {
        public ExpensiveCalculator()
        {
            Thread.Sleep(5000);
        }

        public int Sum(int n1, int n2)
            => n1 + n2;

        public int Multiply(int n1, int n2)
           => n1 * n2;
    }
}
