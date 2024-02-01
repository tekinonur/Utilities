using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Services.Cloudflare.Models;

public class CdnResult
{
    public string id { get; set; }
    public string filename { get; set; }
    public CdnMeta meta { get; set; }
    public DateTime uploaded { get; set; }
    public bool requireSignedURLs { get; set; }
    public List<string> variants { get; set; }
}

