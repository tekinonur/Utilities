using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Services.MailService.Models;

namespace Utilities.Services.MailService
{
    public interface IMailService
    {
        Task SendEmail(MailRequest mailRequest);
    }
}
