using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Services.SmsService.Models;

namespace Utilities.Services.SmsService
{
    public class SmsService : ISmsService
    {
        private readonly SmsSetting _smsSetting;

        private readonly ILogger<SmsService> _logger;

        public SmsService(
            IOptions<SmsSetting> smsSetting,
            ILogger<SmsService> logger)
        {
            _smsSetting = smsSetting.Value;
            _logger = logger;
        }

        public async Task<bool> SendSms(SmsRequest smsRequest)
        {
            _logger.LogWarning($"Sending sms to {string.Join(",", smsRequest.To)} from {_smsSetting.From} with body {smsRequest.Text}.");
            
            
            //TODO: Implement sms service

            await Task.CompletedTask;

            return true;
        }
    }
}