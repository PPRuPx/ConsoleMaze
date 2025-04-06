namespace ConsoleMaze;

class GameData
{
    private static GameData _instance;
    public char[,] Map { get; }

    private GameData() 
    {
        Map = TransformArray(new[,]
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
    }

    public static GameData GetInstance()
    {
        if (_instance == null)
            _instance = new GameData();
        
        return _instance;
    }
    
}