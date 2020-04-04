﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralApp.Mail
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
