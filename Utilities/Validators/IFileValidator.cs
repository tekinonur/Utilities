using Microsoft.AspNetCore.Http;

namespace Utilities.Validators;

public interface IFileValidator
{
    bool IsValid(IFormFile file);
}
