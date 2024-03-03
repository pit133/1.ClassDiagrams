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

        public void ChangeBalance(decimal newBalance)
        {
            _balance = newBalance;
            Notificatoin();
        }
        
    }

    class SMSLowBalanceNotifyer : INotifier
    {
        string _phone;
        decimal _lowBalanceValue;

        public SMSLowBalanceNotifyer(string phone, decimal lowBalanceValue)
        {
            _phone = phone;
            _lowBalanceValue = lowBalanceValue;
        }

        public void Notify(decimal balance)
        {
            string callingClassName = GetType().Name;
            Console.WriteLine($"Метод вызван из класса: {callingClassName}");

            if (balance < _lowBalanceValue)
            {
                Console.WriteLine("Баданс: " + balance);
            }
        }
    }

    class EMailBalanceChangedNotifyer : INotifier
    {
        string _email;

        public EMailBalanceChangedNotifyer(string email)
        {
            _email = email;
        }

        public void Notify(decimal balance) 
        {
            string callingClassName = GetType().Name;
            Console.WriteLine($"Метод вызван из класса: {callingClassName}");
            Console.WriteLine("Баданс: " + balance);
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            
            Account account = new Account(1000);            
            SMSLowBalanceNotifyer smsNotifier = new SMSLowBalanceNotifyer("123456789", 500);
            EMailBalanceChangedNotifyer emailNotifier = new EMailBalanceChangedNotifyer("example@example.com");

            account.AddNotifier(smsNotifier);
            account.AddNotifier(emailNotifier);
            account.ChangeBalance(800);
            account.ChangeBalance(400);
        }
    }
}