using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class WebNotification : INotificationService
    {
        public void NotifyUsernameChanged(User user)
        {
            Console.WriteLine($"WebNotification : Username has been changed to {user.Username}");
        }
    }
}
