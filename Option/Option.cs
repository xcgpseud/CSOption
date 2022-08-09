using Option.Interfaces;

namespace Option;

public abstract class Option<T> : IOption<T>
{
    public static IOption<T> From(T? value)
    {
        return value == null
            ? new None<T>()
            : new Some<T>(value);
    }

    public static IOption<T> From(T? value, params T[] invalidValues)
    {
        return value == null || invalidValues.Contains(value)
            ? new None<T>()
            : new Some<T>(value);
    }

    public static IOption<T> From(T? value, Func<T, bool> invalidFunc)
    {
        return value == null || invalidFunc(value)
            ? new None<T>()
            : new Some<T>(value);
    }

    public static IOption<T> From(T? value, Func<T, bool> invalidFunc, params T[] invalidValues)
    {
        return value == null || invalidFunc(value) || invalidValues.Contains(value)
            ? new None<T>()
            : new Some<T>(value);
    }

    public abstract T Get();

    public abstract T GetOrElse(T defaultValue);

    public abstract T GetOrCall(Func<T> defaultFunc);

    public abstract Task<T> GetOrCallAsync(Func<Task<T>> defaultFunc);

    public abstract T GetOrThrow(Exception defaultException);

    public abstract void IfValid(Action<T> func);

    public abstract void IfValid(Action func);

    public abstract void IfInvalid(Action func);

    public abstract Task IfValidAsync(Func<T, Task> func);

    public abstract Task IfValidAsync(Func<Task> func);

    public abstract bool IsValid();

    public abstract bool IsInvalid();
}