﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    // created for DI
    interface INotificationService
    {
        void NotifyUsernameChanged(User user);
    }
}
