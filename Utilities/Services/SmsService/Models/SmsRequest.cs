using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Services.SmsService.Models
{
    public class SmsRequest
    {
        public string To { get; set; }
        public string Text { get; set; }
    }
}
