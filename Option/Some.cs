namespace Option;

public class Some<T> : Option<T>
{
    private readonly T _value;

    public Some(T value)
    {
        _value = value;
    }

    public override T Get() => _value;

    public override T GetOrElse(T _) => _value;

    public override T GetOrCall(Func<T> _) => _value;

    public override async Task<T> GetOrCallAsync(Func<Task<T>> _) => await Task.FromResult(_value);

    public override T GetOrThrow(Exception _) => _value;

    public override void IfValid(Action<T> func) => func(_value);

    public override void IfValid(Action func) => func();

    public override void IfInvalid(Action _)
    {
    }

    public override async Task IfValidAsync(Func<T, Task> func) => await func(_value);

    public override async Task IfValidAsync(Func<Task> func) => await func();

    public override bool IsValid() => true;

    public override bool IsInvalid() => false;
}