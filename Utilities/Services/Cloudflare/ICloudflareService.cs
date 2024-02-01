using Microsoft.AspNetCore.Http;
using Utilities.Services.Cloudflare.Models;

namespace Utilities.Services.Cloudflare;

public interface ICloudflareService
{
    Task<CdnUploadFileResponse> UploadFile(IFormFile file);
    Task<bool> DeleteFile(string cdnImageId);
}