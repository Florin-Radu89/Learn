using System;

namespace DependencyInjection
{
    //internal class ConsoleNotification    no DI
    internal class ConsoleNotification: INotificationService    //using DI
    {
        public void NotifyUsernameChanged(User user)
        {
            Console.WriteLine($"Username has been changed to {user.Username}");
        }

    }
}
