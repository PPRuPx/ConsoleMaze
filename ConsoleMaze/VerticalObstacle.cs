namespace ConsoleMaze;

public class VerticalObstacle : Unit
{
    private bool _isDownDirection = true;

    public VerticalObstacle(int startX, int startY, char symbol, ConsoleRenderer renderer)
        : base(startX, startY, symbol, renderer)
    {
    }

    public override void Update()
    {
        if (_isDownDirection && !TryMoveDown())
            _isDownDirection = false;

        if (!_isDownDirection && !TryMoveUp())
            _isDownDirection = true;
    }
}