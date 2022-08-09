namespace Option;

public class Some<T> : Option<T>
{
    private readonly T _value;

    protected Some(T value)
    {
        _value = value;
    }

    public override T Get() => _value;

    public override T GetOrElse(T defaultValue) => _value;

    public override T GetOrCall(Func<T> defaultFunc) => _value;

    public override async Task<T> GetOrCallAsync(Func<Task<T>> defaultFunc) => await Task.FromResult(_value);

    public override T GetOrThrow(Exception defaultException) => _value;

    public override void IfValid(Func<T> func) => func();

    public override void IfValid(Action func) => func();

    public override void IfInvalid(Action func) => func();

    public override async Task IfValidAsync(Func<Task<T>> func) => await func();

    public override async Task IfValidAsync(Action func) => func();

    public override bool IsValid() => throw new NotImplementedException();

    public override bool IsInvalid() => throw new NotImplementedException();
}