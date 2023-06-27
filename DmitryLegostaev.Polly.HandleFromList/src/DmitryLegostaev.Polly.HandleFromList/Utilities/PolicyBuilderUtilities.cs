using Polly;

namespace DmitryLegostaev.Polly.HandleFromList.Utilities;

public static class PolicyBuilderUtilities
{
    public static PolicyBuilder<T> HandleFromList<T>(IList<Type>? exceptionsToHandle, bool strictCheck = true)
    {
        ExceptionsListValidator.IsExceptionListValid(exceptionsToHandle, strictCheck);

        return Policy<T>
            .Handle<Exception>(exception => exceptionsToHandle!.Any(type => type.IsInstanceOfType(exception)));
    }
}
