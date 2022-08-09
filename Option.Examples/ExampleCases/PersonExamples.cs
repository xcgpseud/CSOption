using FluentAssertions;
using NUnit.Framework;

namespace Option.Examples.ExampleCases;

[TestFixture]
public class PersonExamples
{
    [Test]
    public void GetPerson_LogPersonNameIfValid_ThrowIfInvalid()
    {
        var repository = FakeRepository.Make();

        var person = Option<Person>
            .From(repository.Get(1))
            .IfValid(person => Console.WriteLine($"Person name: {person.FirstName} {person.LastName}"))
            .GetOrThrow(new Exception());

        person.Should().BeOfType<Person>();
    }
}