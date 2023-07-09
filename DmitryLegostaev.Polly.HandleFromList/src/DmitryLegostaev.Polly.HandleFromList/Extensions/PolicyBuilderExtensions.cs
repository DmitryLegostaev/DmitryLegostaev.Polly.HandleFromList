using DmitryLegostaev.Polly.HandleFromList.Utilities;
using Polly;

namespace DmitryLegostaev.Polly.HandleFromList.Extensions;

public static class PolicyBuilderExtensions
{
    /// <summary>Adds an "OrFromList" policy to the current <see cref="PolicyBuilder{T}"/> based on a list of exception types.</summary>
    /// <typeparam name="T">The type of result for the policy.</typeparam>
    /// <param name="policyBuilder">The current <see cref="PolicyBuilder{T}"/> instance.</param>
    /// <param name="exceptionsToHandle">The list of exception types to handle.</param>
    /// <param name="strictCheck">Flag indicating whether to perform a strict check for given <paramref name="exceptionsToHandle"/>. Default is false.</param>
    /// <returns>The modified <see cref="PolicyBuilder{T}"/> instance with the "OrFromList" policy added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exceptionsToHandle"/> is null or empty and <paramref name="strictCheck"/> is true.</exception>
    /// <exception cref="ArgumentException">Thrown when any of the types in <paramref name="exceptionsToHandle"/> do not derive from <see cref="System.Exception"/>.</exception>
    public static PolicyBuilder<T> OrFromList<T>(this PolicyBuilder<T> policyBuilder,
        IList<Type>? exceptionsToHandle, bool strictCheck = false)
    {
        if (ExceptionsListValidator.IsExceptionListValid(exceptionsToHandle, strictCheck))
        {
            policyBuilder
                .Or<Exception>(exception => exceptionsToHandle!.Any(type => type.IsInstanceOfType(exception)));
        }

        return policyBuilder;
    }

    /// <summary>Adds an "OrFromList" policy to the current <see cref="PolicyBuilder"/> based on a list of exception types.</summary>
    /// <param name="policyBuilder">The current <see cref="PolicyBuilder"/> instance.</param>
    /// <param name="exceptionsToHandle">The list of exception types to handle.</param>
    /// <param name="strictCheck">Flag indicating whether to perform a strict check for given <paramref name="exceptionsToHandle"/>. Default is false.</param>
    /// <returns>The modified <see cref="PolicyBuilder"/> instance with the "OrFromList" policy added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exceptionsToHandle"/> is null or empty and <paramref name="strictCheck"/> is true.</exception>
    /// <exception cref="ArgumentException">Thrown when any of the types in <paramref name="exceptionsToHandle"/> do not derive from <see cref="System.Exception"/>.</exception>
    public static PolicyBuilder OrFromList(this PolicyBuilder policyBuilder,
        IList<Type>? exceptionsToHandle, bool strictCheck = false)
    {
        if (ExceptionsListValidator.IsExceptionListValid(exceptionsToHandle, strictCheck))
        {
            policyBuilder
                .Or<Exception>(exception => exceptionsToHandle!.Any(type => type.IsInstanceOfType(exception)));
        }

        return policyBuilder;
    }
}
