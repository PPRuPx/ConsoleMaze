using System.Collections;

namespace ConsoleMaze;

public class UnitsEnumerator : IEnumerator
{
    private List<Unit> _units;
    private int _position = -1;
    
    public UnitsEnumerator(List<Unit> units)
    {
        _units = units;
    }
    
    public bool MoveNext()
    {
        if (_position < _units.Count - 1)
        {
            _position++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current => _units[_position];
}