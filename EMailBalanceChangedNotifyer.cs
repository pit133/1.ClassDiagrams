using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class EMailBalanceChangedNotifyer : INotifyer
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
}
