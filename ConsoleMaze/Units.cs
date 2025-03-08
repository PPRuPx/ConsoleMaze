using System.Collections;

namespace ConsoleMaze;

public class Units : IEnumerable
{
    private List<Unit> _units = new List<Unit>();

    public void Add(Unit unit)
    {
        _units.Add(unit);
    }

    public void Remove(Unit unit)
    {
        _units.Remove(unit);
    }

    public IEnumerator GetEnumerator()
    {
        return _units.GetEnumerator();
    }
}