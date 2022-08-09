using Option.Interfaces;

namespace Option;

public abstract class Option<T> : IOption<T>
{
    public abstract T Get();

    public abstract T GetOrElse(T defaultValue);

    public abstract T GetOrCall(Func<T> defaultFunc);

    public abstract Task<T> GetOrCallAsync(Func<Task<T>> defaultFunc);

    public abstract T GetOrThrow(Exception defaultException);

    public abstract void IfValid(Func<T> func);

    public abstract void IfValid(Action func);

    public abstract void IfInvalid(Action func);

    public abstract Task IfValidAsync(Func<Task<T>> func);

    public abstract Task IfValidAsync(Action func);

    public abstract bool IsValid();

    public abstract bool IsInvalid();
}