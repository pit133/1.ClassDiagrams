using System.Security.Principal;

namespace DZ1
{
    interface INotifier
    {
        void Notify(decimal balance);
    }

    class Account
    {
        private decimal _balance;
        List<INotifier> _notifyers;

        public Account()
        {
            _balance = 0;
            _notifyers = new List<INotifier>();
        }
        public Account(decimal initialBalance)
        {
            _balance = initialBalance;
            _notifyers = new List<INotifier>();
        }

        private decimal Balance { get { return _balance; } }

        public void AddNotifier(INotifier notifyer)
        {
            _notifyers.Add(notifyer);
        }

        private void Notificatoin()
        {
            foreach (var item in _notifyers)
            {
                item.Notify(_balance);
            }
        }

        private void ChangeBalance(decimal newBalance)
        {
            _balance = newBalance;
            Notificatoin();
        }
        
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}