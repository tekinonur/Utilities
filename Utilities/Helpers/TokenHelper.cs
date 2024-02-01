using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Utilities.Helpers;

public static class TokenHelper
{
    public static string CreateRandomToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(8));
    }

    public static string CreateSMSToken()
    {
        return new Random().Next(1000, 10000).ToString();
    }
}