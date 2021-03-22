namespace DependencyInjection
{
    internal class User
    {
        // ConsoleNotification iS a dependency of User class OR User class depend on ConsoleNotification
        //private ConsoleNotification _notificationService;
        // we want User class don't depend on ConsoleNofication, so create INotificationService:
        private INotificationService _notificationService;
        /*DIP: High-level modules should not depend on low-level modules. Both should depend on abstractions.
Abstractions should not depend on details. Details should depend on abstractions.
        */
        //public User(string username)  without DI
        public User(string username, INotificationService notificationService)  // with DI: injecting Service in constr.
        {
            Username = username;
            //_notificationService = new ConsoleNotification();    parameter notificationService injected
            _notificationService = notificationService;
        }

        public string Username { get; private set; }

        public void ChangeUsername(string newUsername)
        {
            Username = newUsername;
            _notificationService.NotifyUsernameChanged(this);
        }
    }
}
