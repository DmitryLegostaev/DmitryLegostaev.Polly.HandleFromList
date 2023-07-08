using Polly;

namespace DmitryLegostaev.Polly.HandleFromList.Utilities;

public static class PolicyBuilderUtilities
{
    /// <summary>Creates a <see cref="PolicyBuilder{T}"/> instance that handles exceptions based on a list of exception types.</summary>
    /// <typeparam name="T">The type of result for the policy.</typeparam>
    /// <param name="exceptionsToHandle">The list of exception types to handle.</param>
    /// <param name="strictCheck">Flag indicating whether to perform a strict check. Default is true.</param>
    /// <returns>The <see cref="PolicyBuilder{T}"/> instance that handles the specified exception types.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exceptionsToHandle"/> is null or empty and <paramref name="strictCheck"/> is true.</exception>
    /// <exception cref="ArgumentException">Thrown when any of the types in <paramref name="exceptionsToHandle"/> do not derive from <see cref="System.Exception"/>.</exception>
    public static PolicyBuilder<T> HandleFromList<T>(IList<Type>? exceptionsToHandle, bool strictCheck = true)
    {
        ExceptionsListValidator.IsExceptionListValid(exceptionsToHandle, strictCheck);

        return Policy<T>
            .Handle<Exception>(exception => exceptionsToHandle!.Any(type => type.IsInstanceOfType(exception)));
    }

    public static PolicyBuilder HandleFromList(IList<Type>? exceptionsToHandle, bool strictCheck = true)
    {
        ExceptionsListValidator.IsExceptionListValid(exceptionsToHandle, strictCheck);
        return Policy.Handle<Exception>(exception => exceptionsToHandle!.Any(type => type.IsInstanceOfType(exception)));
    }
}
