using Microsoft.AspNetCore.Http;
using Utilities.Services.CloudflareService.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace Utilities.Services.CloudflareService;

/// <summary>
/// Bu servis genişletebilecek cdn den içerik silme vs eklenemsi lazım
/// </summary>
public class CloudflareService : ICloudflareService
{
    const string Base_URL = "https://api.cloudflare.com/";
    const string Account_ID = "<TODO:Account_ID>";
    const string API_TOKEN = "<TODO:API_TOKEN>";

    public async Task<CdnUploadFileResponse> UploadFile(IFormFile file)
    {
        //https://developers.cloudflare.com/images/upload-images/upload-url/
        //curl--request POST \
        //--url https://api.cloudflare.com/client/v4/accounts/<ACCOUNT_ID>/images/v1 \
        //--header 'Authorization: Bearer <API_TOKEN>' \
        //--form 'url=https://[user:password@]example.com/<PATH_TO_IMAGE>' \
        //--form 'metadata={"key":"value"}' \
        //--form 'requireSignedURLs=false'

        string apiEndpoint = $"{Base_URL}client/v4/accounts/{Account_ID}/images/v1";

        string metadata = "{\"key\":\"value\"}";

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_TOKEN}");

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
            content.Add(new StringContent(metadata), "metadata");
            content.Add(new StringContent("false"), "requireSignedURLs");

            var response = await httpClient.PostAsync(apiEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                CdnUploadFileResponse resObj = JsonConvert.DeserializeObject<CdnUploadFileResponse>(responseBody);

                return resObj;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }

    public async Task<bool> DeleteFile(string cdnImageId)
    {
        //https://developers.cloudflare.com/images/manage-images/delete-images/
        //curl - X DELETE https://api.cloudflare.com/client/v4/accounts/<ACCOUNT_ID>/images/v1/<IMAGE_ID> \
        //--header 'Authorization: Bearer <API_TOKEN>'

        string apiEndpoint = $"{Base_URL}client/v4/accounts/{Account_ID}/images/v1/{cdnImageId}";

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_TOKEN}");
            var response = await httpClient.DeleteAsync(apiEndpoint);

            return response.IsSuccessStatusCode;
        }
    }
}