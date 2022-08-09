using FluentAssertions;
using NUnit.Framework;
using Option.Interfaces;

namespace Option.Tests.TestCases;

[TestFixture]
public class SomeTests
{
    private const string ValidValue = "Valid Value";

    private const string DefaultValue = "Default Value";

    [Test]
    public void Some_Get_ReturnsValue()
    {
        var some = GetSome();

        some.Get().Should().Be(ValidValue);
    }

    [Test]
    public void Some_GetOrElse_ReturnsValue()
    {
        var some = GetSome();

        some.GetOrElse(DefaultValue).Should().Be(ValidValue);
    }

    [Test]
    public void Some_GetOrCall_ReturnsValue()
    {
        var some = GetSome();

        some.GetOrCall(() => DefaultValue).Should().Be(ValidValue);
    }

    [Test]
    public async Task Some_GetOrCallAsync_ReturnsValue()
    {
        var some = GetSome();

        var result = await some.GetOrCallAsync(async () => await Task.FromResult(DefaultValue));
        result.Should().Be(ValidValue);
    }

    [Test]
    public void Some_GetOrThrow_ReturnsValue()
    {
        var some = GetSome();

        var result = some.GetOrThrow(new Exception());
        result.Should().Be(ValidValue);
    }

    [Test]
    public void Some_IfValid_RunsActionWithString()
    {
        var some = GetSome();
        var output = string.Empty;

        some.IfValid(x => output = x);

        output.Should().Be(ValidValue);
    }

    [Test]
    public void Some_IfValid_RunsActionWithoutString()
    {
        var some = GetSome();
        var output = string.Empty;

        some.IfValid(() => output = DefaultValue);

        output.Should().Be(DefaultValue);
    }

    [Test]
    public void Some_IfInvalid_DoesNothing()
    {
        var some = GetSome();
        var output = string.Empty;

        some.IfInvalid(() => output = DefaultValue);

        output.Should().BeEmpty();
    }

    [Test]
    public void Some_IfValidAsync_RunsActionWithString()
    {
        var some = GetSome();
        var output = string.Empty;

        some.IfValidAsync(async x =>
        {
            output = x;

            // Just await something :p
            await Task.CompletedTask;
        });

        output.Should().Be(ValidValue);
    }

    [Test]
    public void Some_IfValidAsync_RunsActionWithoutString()
    {
        var some = GetSome();
        var output = string.Empty;

        some.IfValidAsync(async () =>
        {
            output = DefaultValue;

            await Task.CompletedTask;
        });

        output.Should().Be(DefaultValue);
    }

    [Test]
    public void Some_IsValid_IsTrue()
    {
        var some = GetSome();

        some.IsValid().Should().BeTrue();
    }

    [Test]
    public void Some_IsInvalid_IsFalse()
    {
        var some = GetSome();

        some.IsInvalid().Should().BeFalse();
    }

    private static IOption<string> GetSome()
    {
        return Option<string>.From(ValidValue);
    }
}