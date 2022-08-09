namespace Option.Examples;

public class FakeRepository
{
    private readonly List<Person> _people;

    public FakeRepository()
    {
        _people = Enumerable.Range(1, 5)
            .Select(i => new Person
            {
                Id = i,
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
            })
            .ToList();
    }

    public static FakeRepository Make()
    {
        return new FakeRepository();
    }

    public Person? Get(int id)
    {
        return _people.FirstOrDefault(person => person.Id == id);
    }
}