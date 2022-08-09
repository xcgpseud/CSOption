using FluentAssertions;
using NUnit.Framework;
using Option.Exceptions;

namespace Option.Tests.TestCases;

[TestFixture]
public class OptionFromTests
{
    /** No extra params **/
    [TestCase("hello")]
    [TestCase("world")]
    [TestCase("")]
    public void OptionFrom_ValidValue_ReturnsSome(string validValue)
    {
        var result = Option<string>.From(validValue);

        result.Should().BeOfType<Some<string>>();
        result.Get().Should().Be(validValue);
    }

    [Test]
    public void OptionFrom_InvalidValue_ReturnsNone()
    {
        var result = Option<string>.From(null);

        result.Should().BeOfType<None<string>>();
        result.Invoking(x => x.Get()).Should().Throw<OptionValueNotFoundException>();
    }

    /** Invalid value params **/
    [TestCase("")]
    [TestCase("hello")]
    public void OptionFrom_ValidValue_InvalidValueParams_ReturnsSome(string validValue)
    {
        var result = Option<string>.From(validValue, "world");

        result.Should().BeOfType<Some<string>>();
        result.Get().Should().Be(validValue);
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("hello")]
    [TestCase("world")]
    public void OptionFrom_InvalidValue_InvalidValueParams_ReturnsNone(string invalidValue)
    {
        var result = Option<string>.From(invalidValue, "hello", "world", "");

        result.Should().BeOfType<None<string>>();
        result.Invoking(x => x.Get()).Should().Throw<OptionValueNotFoundException>();
    }

    /** Invalid function param **/
    [TestCase("HeLLO")]
    [TestCase("world")]
    public void OptionFrom_ValidValue_InvalidValueFunc_ReturnsSome(string validValue)
    {
        var result = Option<string>.From(validValue, x => x == x.ToUpper());

        result.Should().BeOfType<Some<string>>();
        result.Get().Should().Be(validValue);
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("HELLO")]
    [TestCase("WORLD")]
    public void OptionFrom_InvalidValue_InvalidValueFunc_ReturnsNone(string invalidValue)
    {
        var result = Option<string>.From(invalidValue, x => x == x.ToUpper());

        result.Should().BeOfType<None<string>>();
        result.Invoking(x => x.Get()).Should().Throw<OptionValueNotFoundException>();
    }

    /** Invalid function and invalid value params **/
    [TestCase("HeLLO")]
    [TestCase("wOrld")]
    public void OptionFrom_ValidValue_InvalidValueFunc_InvalidValueParams_ReturnsSome(string validValue)
    {
        var result = Option<string>.From(validValue, x => x == x.ToUpper(), "world");

        result.Should().BeOfType<Some<string>>();
        result.Get().Should().Be(validValue);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("HELLO")]
    [TestCase("world")]
    [TestCase("spaghetti")]
    public void OptionFrom_InvalidValue_InvalidValueFunc_InvalidValueParams_ReturnsNone(string invalidValue)
    {
        var result = Option<string>.From(
            invalidValue,
            x => x == x.ToUpper(),
            "world",
            "spaghetti"
        );
        
        result.Should().BeOfType<None<string>>();
        result.Invoking(x => x.Get()).Should().Throw<OptionValueNotFoundException>();
    }
}