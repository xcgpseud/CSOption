using Option.Interfaces;

namespace Option.Tests;

public class TestBase
{
    protected const string ValidValue = TestConstants.Values.Valid;
    protected const string DefaultValue = TestConstants.Values.Default;
    protected const string ExceptionMessage = TestConstants.ExceptionMessage;
    
    protected static IOption<string> GetSome()
    {
        return Option<string>.From(ValidValue);
    }

    protected static IOption<string> GetNone()
    {
        return Option<string>.From(null);
    }
}