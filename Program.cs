using System.Security.Principal;

namespace DZ1
{
    interface INotifier
    {
        void Notify(decimal balance);
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}