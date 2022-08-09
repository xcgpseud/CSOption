using System.Runtime.InteropServices.ComTypes;
using Option.Exceptions;
using Option.Interfaces;

namespace Option;

public class None<T> : Option<T>
{
    public override T Get() => throw new OptionValueNotFoundException("Tried to access value in NONE.");

    public override T GetOrElse(T defaultValue) => defaultValue;

    public override T GetOrCall(Func<T> defaultFunc) => defaultFunc();

    public override async Task<T> GetOrCallAsync(Func<Task<T>> defaultFunc) => await defaultFunc();

    public override T GetOrThrow(Exception defaultException) => throw defaultException;

    public override IOption<T> IfValid(Action<T> _) => this;

    public override IOption<T> IfValid(Action _) => this;

    public override IOption<T> IfInvalid(Action func)
    {
        func();

        return this;
    }

    public override async Task<IOption<T>> IfValidAsync(Func<T, Task> _) => await Task.FromResult(this);
W
    public override async Task<IOption<T>> IfValidAsync(Func<Task> _) => await Task.FromResult(this);

    public override bool IsValid() => false;

    public override bool IsInvalid() => true;
}