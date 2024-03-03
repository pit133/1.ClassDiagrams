using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Account
    {
        private decimal _balance;
        List<INotifyer> _notifyers;

        public Account()
        {
            _balance = 0;
            _notifyers = new List<INotifyer>();
        }
        public Account(decimal initialBalance)
        {
            _balance = initialBalance;
            _notifyers = new List<INotifyer>();
        }

        private decimal Balance { get { return _balance; } }

        public void AddNotifier(INotifyer notifyer)
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
}
