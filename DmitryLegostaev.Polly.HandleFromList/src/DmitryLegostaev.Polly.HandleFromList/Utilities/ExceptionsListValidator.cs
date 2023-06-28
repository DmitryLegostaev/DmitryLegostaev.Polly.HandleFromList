namespace DmitryLegostaev.Polly.HandleFromList.Utilities;

public static class ExceptionsListValidator
{
    /// <summary>Checks if the given exception list is valid.</summary>
    /// <param name="exceptionsToHandle">The list of exception types to handle.</param>
    /// <param name="strictCheck">Flag indicating whether to throw an exception when the list is null/empty. Default is false.</param>
    /// <returns>Returns true if the exception list is valid; otherwise, false when <paramref name="strictCheck"/> is false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exceptionsToHandle"/> is null or empty and <paramref name="strictCheck"/> is true.</exception>
    /// <exception cref="ArgumentException">Thrown when any of the types in <paramref name="exceptionsToHandle"/> do not derive from <see cref="System.Exception"/>.</exception>
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
