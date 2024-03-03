using System.Security.Principal;

namespace DZ1
{
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