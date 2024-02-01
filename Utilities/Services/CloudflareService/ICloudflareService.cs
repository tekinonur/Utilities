using Microsoft.AspNetCore.Http;
using Utilities.Services.CloudflareService.Models;

namespace Utilities.Services.CloudflareService;

public interface ICloudflareService
{
    Task<CdnUploadFileResponse> UploadFile(IFormFile file);
    Task<bool> DeleteFile(string cdnImageId);
}