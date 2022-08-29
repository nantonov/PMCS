namespace Schedule.Domain.SeedWork;

public abstract class Enumeration
{
    private string _name;
    public string GetName => _name;

    private int _id;
    public int GetId => _id;

    protected Enumeration(int id, string name) => (_id, _name) = (id, name);
    public abstract IEnumerable<Enumeration> Types();

    public override string ToString() => _name;

    protected string PossibleValues()
    {
        return String.Join(",", Types().Select(s => s.GetName));
    }
}
