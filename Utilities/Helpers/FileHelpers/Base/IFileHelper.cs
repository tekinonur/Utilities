namespace Utilities.Helpers.FileHelpers.Base;

public interface IFileHelper : IHelper
{
    Task<string> ReadTextFromFileAsync(string filePath);
    Task WriteTextToFileAsync(string filePath, string content);
}