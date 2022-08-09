namespace Option.Exceptions;

public class OptionValueNotFoundException : Exception
{
    public OptionValueNotFoundException() : base()
    {
    }

    public OptionValueNotFoundException(string message) : base(message)
    {
    }
}