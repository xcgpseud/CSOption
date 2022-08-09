namespace Option.Interfaces;

public interface IOption<T>
{
    // Get the value
    public T Get();

    // Get the value with fallback VALUE
    public T GetOrElse(T defaultValue);

    // Get the value with fallback ACTION
    public T GetOrCall(Func<T> defaultFunc);

    // Get the value with fallback ASYNC ACTION
    public Task<T> GetOrCallAsync(Func<Task<T>> defaultFunc);

    // Get the value with fallback EXCEPTION
    public T GetOrThrow(Exception defaultException);

    // If VALID do something
    public IOption<T> IfValid(Action<T> func);
    public IOption<T> IfValid(Action func);

    // If INVALID do something
    public IOption<T> IfInvalid(Action func);

    // If VALID / INVALID do something ASYNC
    public Task<IOption<T>> IfValidAsync(Func<T, Task> func);
    public Task<IOption<T>> IfValidAsync(Func<Task> func);

    // Is valid ?
    public bool IsValid();

    // Is invalid ?
    public bool IsInvalid();
}