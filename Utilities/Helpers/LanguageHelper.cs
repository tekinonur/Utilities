using System;

namespace Utilities.Helpers;

public static class LanguageHelper
{
    /// <summary>
    /// Runs an operation and ignores any Exceptions that occur.
    /// Returns true or falls depending on whether catch was
    /// triggered
    /// </summary>
    /// <param name="operation">lambda that performs an operation that might throw</param>
    /// <returns></returns>
    public static bool IgnoreErrors(Action operation)
    {
        if (operation == null)
            return false;

        try
        {
            operation.Invoke();
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Runs an function that returns a value and ignores any Exceptions that occur.
    /// Returns true or falls depending on whether catch was
    /// triggered
    /// </summary>
    /// <param name="operation">parameterless lamda that returns a value of T</param>
    /// <param name="defaultValue">Default value returned if operation fails</param>
    public static T IgnoreErrors<T>(Func<T> operation, T defaultValue = default(T))
    {
        if (operation == null)
            return defaultValue;

        T result;
        try
        {
            result = operation.Invoke();
        }
        catch
        {
            result = defaultValue;
        }

        return result;
    }
}