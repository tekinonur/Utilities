using Utilities.Helpers.FileHelpers.Base;

namespace Utilities.Helpers.FileHelpers;

public class FileHelper : IFileHelper
{
    public async Task<string> ReadTextFromFileAsync(string filePath)
    {
        try
        {
            return await File.ReadAllTextAsync(filePath);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
            return string.Empty;
        }
    }

    public async Task WriteTextToFileAsync(string filePath, string content)
    {
        try
        {
            await File.WriteAllTextAsync(filePath, content);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }
}