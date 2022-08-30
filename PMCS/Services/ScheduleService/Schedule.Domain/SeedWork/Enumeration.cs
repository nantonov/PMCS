using Schedule.Domain.Exceptions;

namespace Schedule.Domain.SeedWork;

public abstract class Enumeration
{
    private string _name;
    public string GetName => _name;

    private int _id;
    public int GetId => _id;

    protected Enumeration(int id, string name) => (_id, _name) = (id, name);
    protected abstract IEnumerable<Enumeration> Types();

    public override string ToString() => _name;
    protected abstract IReadOnlyList<int> PossibleIds();

    public void ValidateId(int value)
    {
        if (!PossibleIds().Contains(value))
            throw new ScheduleDomainException($"Type with id {value} does not exist.");
    }
}
