using FluentAssertions;
using NUnit.Framework;
using Option.Exceptions;
using Option.Interfaces;

namespace Option.Tests.TestCases;

[TestFixture]
public class NoneTests : TestBase
{

    [Test]
    public void None_Get_ThrowsCorrectException()
    {
        var none = GetNone();

        none.Invoking(x => x.Get()).Should().Throw<OptionValueNotFoundException>();
    }

    [Test]
    public void None_GetOrElse_ReturnsDefaultValue()
    {
        var none = GetNone();

        none.GetOrElse(DefaultValue).Should().Be(DefaultValue);
    }

    [Test]
    public void None_GetOrCall_CallsDefaultFunc()
    {
        var none = GetNone();

        none.GetOrCall(() => DefaultValue).Should().Be(DefaultValue);
    }

    [Test]
    public async Task None_GetOrCallAsync_CallsDefaultAsyncFunc()
    {
        var none = GetNone();

        var result = await none.GetOrCallAsync(async () => await Task.FromResult(DefaultValue));
        result.Should().Be(DefaultValue);
    }

    [Test]
    public void None_GetOrThrow_ThrowsDefaultException()
    {
        var none = GetNone();

        none.Invoking(x => x.GetOrThrow(new Exception(ExceptionMessage)))
            .Should().Throw<Exception>()
            .WithMessage(ExceptionMessage);
    }

    [Test]
    public void None_IfValid_DoesNothing()
    {
        var none = GetNone();
        var output = string.Empty;

        none.IfValid(x => output = x);
        none.IfValid(() => output = DefaultValue);

        output.Should().BeEmpty();
    }

    [Test]
    public void None_IfInvalid_CallsAction()
    {
        var none = GetNone();
        var output = string.Empty;

        none.IfInvalid(() => output = DefaultValue);

        output.Should().Be(DefaultValue);
    }

    [Test]
    public async Task None_IfValidAsync_DoesNothing()
    {
        var none = GetNone();
        var output = string.Empty;

        await none.IfValidAsync(async x => output = x);
        await none.IfValidAsync(async () => output = DefaultValue);

        output.Should().BeEmpty();
    }

    [Test]
    public void None_IsValid_IsFalse()
    {
        var none = GetNone();

        none.IsValid().Should().BeFalse();
    }

    [Test]
    public void None_IsInvalid_IsTrue()
    {
        var none = GetNone();

        none.IsInvalid().Should().BeTrue();
    }
}