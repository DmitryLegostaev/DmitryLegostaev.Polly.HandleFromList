using DmitryLegostaev.Polly.HandleFromList.Utilities;
using Polly;

namespace DmitryLegostaev.Polly.HandleFromList.Extensions;

public static class PolicyBuilderExtensions
{
    public static PolicyBuilder<T> OrFromList<T>(this PolicyBuilder<T> handleResultPolicyBuilder,
        IList<Type>? exceptionsToHandle, bool strict = false)
    {
        if (ExceptionsListValidator.IsExceptionListValid(exceptionsToHandle, strict))
        {
            handleResultPolicyBuilder
                .Or<Exception>(exception => exceptionsToHandle!.Any(type => type.IsInstanceOfType(exception)));
        }

        return handleResultPolicyBuilder;
    }
}
