using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;
using System.IO;

namespace Utilities.Services.NotificationService.Firebase
{
    public static class FirebaseInitializer
    {
        public static void Initialize()
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
            });
        }

        public static void InitializeFromJson(string json)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromJson(json)
            });
        }

        public static void InitializeFromFile(string path)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(path)
            });
        }
    }
}
