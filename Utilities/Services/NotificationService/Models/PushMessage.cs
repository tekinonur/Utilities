namespace Utilities.Services.NotificationService.Models;

public class PushMessage
{
    public string DeviceToken { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Dictionary<string, string> Data { get; set; }
    public PushMessage()
    {

    }
    public PushMessage(string deviceToken, string title, string body, Dictionary<string, string> data = null)
    {
        DeviceToken = deviceToken;
        Title = title;
        Body = body;
        Data = data;
    }
}