using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        //https://youtu.be/fvPPlY31glk
        static void Main(string[] args)
        {
            //var user = new User("Tim");  without DI

            //using DI
            INotificationService notificationService = new ConsoleNotification();
            User user = new User("Tim", notificationService);    // we inject notificationService in constructor of User class

            user.ChangeUsername("Robert");

            //other method of notification added:
            INotificationService webNotService = new WebNotification();
            User user_Web = new User("weby", webNotService);
            user_Web.ChangeUsername("WEBX");

        }
    }
}
