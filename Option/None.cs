using System.Runtime.InteropServices.ComTypes;
using Option.Exceptions;

namespace Option;

public class None<T> : Option<T>
{
    public override T Get() => throw new OptionValueNotFoundException("Tried to access value in NONE.");

    public override T GetOrElse(T defaultValue) => defaultValue;

    public override T GetOrCall(Func<T> defaultFunc) => defaultFunc();

    public override async Task<T> GetOrCallAsync(Func<Task<T>> defaultFunc) => await defaultFunc();

    public override T GetOrThrow(Exception defaultException) => throw defaultException;

    public override void IfValid(Action<T> _)
    {
    }

    public override void IfValid(Action _)
    {
    }

    public override void IfInvalid(Action func) => func();

    public override async Task IfValidAsync(Func<T, Task> _) => await Task.CompletedTask;

    public override async Task IfValidAsync(Func<Task> _) => await Task.CompletedTask;

    public override bool IsValid() => false;

    public override bool IsInvalid() => true;
}