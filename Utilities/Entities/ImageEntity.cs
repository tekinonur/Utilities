using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Extensions;

namespace Utilities.Entities
{
    public abstract class ImageEntity : AuditableLoggedEntity
    {
        /// <summary>
        /// Base64 0
        /// Url 1
        /// 
        /// Base64=> ImageData,ImageLowData,ImageSizeMB
        /// Url => ImageCdnId,ImageUrl
        /// </summary>
        public int ImageType { get; set; }

        public byte[]? ImageData { get; set; }
        public byte[]? ImageLowData { get; set; }
        public double? ImageSizeMB { get; set; }

        public string? ImageCdnId { get; set; }
        public string? ImageUrl { get; set; }

        public ImageEntity()
        {
            ImageType = Enums.ImageType.Base64.ToInt();
        }
    }
}
