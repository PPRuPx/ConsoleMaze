namespace ConsoleMaze;

abstract class Program
{
    static void Main(string[] args)
    {
        char[,] map = TransformArray(new[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', '#', '#', '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        });
        
        var renderer = new ConsoleRenderer();
        DrawMap(map, renderer);

        var player = new Player(1, 1, renderer, map);
        var obstacle1 = new VerticalObstacle(4, 1, '!', renderer, map);
        var obstacle2 = new VerticalObstacle(5, 8, '!', renderer, map);
        var smartEnemy = new SmartEnemy(8, 8, '$', renderer, map, player);
        
        var units = new Units
        {
            player,
            obstacle1,
            obstacle2,
            smartEnemy
        };

        while (true)
        {
            foreach (Unit unit in units) unit.Update();
            
            renderer.Render();
            Thread.Sleep(300);

            foreach (Unit unit in units)
                if (unit != player && isCollide(player, unit)) 
                    GameOver();
        }
    }
    
    static char[,] TransformArray(char[,] map) => 
        MirrorVertically(Rotate90Clockwise(map));

    static char[,] Rotate90Clockwise(char[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);
        char[,] rotated = new char[cols, rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                rotated[j, rows - 1 - i] = map[i, j];

        return rotated;
    }

    static char[,] MirrorVertically(char[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);
        char[,] mirrored = new char[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++) 
                mirrored[i, cols - 1 - j] = map[i, j];

        return mirrored;
    }
    
    static void DrawMap(char[,] map, ConsoleRenderer renderer)
    {
        for (int i = 0; i < map.GetLength(0); i++)
            for (int j = 0; j < map.GetLength(1); j++)
                renderer.SetPixel(i, j, map[i , j]);
    }
    
    static bool isCollide(Unit unit1, Unit unit2) =>
        unit1.X == unit2.X && unit1.Y == unit2.Y;

    static void GameOver()
    {
        Environment.Exit(0);
    }
}