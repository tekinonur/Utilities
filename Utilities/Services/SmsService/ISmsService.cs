using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Services.SmsService.Models;

namespace Utilities.Services.SmsService
{
    public interface ISmsService
    {
        Task<bool> SendSms(SmsRequest smsRequest);
    }
}
