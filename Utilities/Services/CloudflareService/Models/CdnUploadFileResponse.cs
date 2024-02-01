using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Services.CloudflareService.Models;

public class CdnUploadFileResponse
{
    public CdnResult result { get; set; }
    public bool success { get; set; }
    public List<object> errors { get; set; }
    public List<object> messages { get; set; }
}

