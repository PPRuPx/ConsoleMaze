namespace ConsoleMaze;

abstract class Program
{
    static void Main(string[] args)
    {
        var renderer = new ConsoleRenderer();
        var input = new ConsoleInput();
        DrawMap(GameData.GetInstance().Map, renderer);

        var player = new Player(1, 1, renderer, input);
        var obstacle1 = new VerticalObstacle(4, 1, '!', renderer);
        var obstacle2 = new VerticalObstacle(5, 8, '!', renderer);
        var smartEnemy = new SmartEnemy(8, 8, '$', renderer, player);

        var units = new List<Unit>()
        {
            player,
            obstacle1,
            obstacle2,
            smartEnemy
        };

        while (true)
        {
            input.Update();

            foreach (Unit unit in units)
                unit.Update();

            renderer.Render();
            Thread.Sleep(300);

            foreach (Unit unit in units)
                if (unit != player && IsCollide(player, unit))
                    GameOver();
        }
    }

    static void DrawMap(char[,] map, ConsoleRenderer renderer)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        for (int j = 0; j < map.GetLength(1); j++)
            renderer.SetPixel(i, j, map[i, j]);
    }

    static bool IsCollide(Unit unit1, Unit unit2) =>
        unit1.X == unit2.X && unit1.Y == unit2.Y;

    static void GameOver() =>
        Environment.Exit(0);
}