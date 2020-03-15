using System;
using System.Threading.Tasks;

namespace MediumTest.SetupExamples
{
    public interface ISample
    {
        string Name { get; }
        string Lastname { get; set; }
        string FormatString(string value);
        bool Check(int number);
        Task<bool> Calculate(params int[] numbers);
        int Count();
        Something Something { get; }
        bool TryConvert(string value, out int output);
        bool DoSomething(ref Something something);
    }


    public interface IFoo
    {
        int Foo();
    }
    public interface IBar
    {
        string Bar();
    }

    public abstract class SomethingBase : IFoo, IBar
    {
        public bool DoSomething()
        {
            Random rnd = new Random();
            var v = rnd.Next(0, 20);
            return v % 2 == 0;
        }

        public virtual string DoSomestring()
        {
            return "some string";
        }

        public string Bar()
        {
            return string.Empty;
        }

        public int Foo()
        {
            return 2020;
        }
    }

    public class Something : SomethingBase
    {
        public override string DoSomestring()
        {
            return "Emre";
        }
    }

}
