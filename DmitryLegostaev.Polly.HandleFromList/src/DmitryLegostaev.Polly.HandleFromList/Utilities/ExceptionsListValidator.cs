namespace DmitryLegostaev.Polly.HandleFromList.Utilities;

public static class ExceptionsListValidator
{
    public static bool IsExceptionListValid(IList<Type>? exceptionsToHandle, bool strictCheck = false)
    {
        if (exceptionsToHandle is null || exceptionsToHandle.Count == 0)
        {
            if (strictCheck)
            {
                throw new ArgumentNullException(nameof(exceptionsToHandle), $"{nameof(exceptionsToHandle)} list cannot be null or empty");
            }

            return false; // Exception list is null or empty
        }

        if (exceptionsToHandle.Any(exceptionType => !typeof(Exception).IsAssignableFrom(exceptionType)))
        {
            throw new ArgumentException("All types to be handled must derive from System.Exception", nameof(exceptionsToHandle));
        }

        return true; // All checks passed
    }
}
