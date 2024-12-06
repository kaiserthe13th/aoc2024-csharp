string[] map = File.ReadAllLines("input");

bool shouldBreak = false;
int guardX = 0, guardY = 0;
Direction guardDirection = Direction.Up;
for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map.Length; j++)
    {
        if (map[i][j] == '^')
        {
            guardY = i;
            guardX = j;
            shouldBreak = true;
            break;
        }
    }
    if (shouldBreak) break;
}

HashSet<(int, int)> guardVisited = new HashSet<(int, int)>();

bool shouldQuit = false;
while (!shouldQuit)
{
    _ = guardVisited.Add((guardX, guardY));
    switch (guardDirection)
    {
        case Direction.Up:
            if (guardY < 1)
            {
                shouldQuit = true;
                break;
            }
            if (map[guardY - 1][guardX] == '#')
            {
                guardDirection = TurnRight(guardDirection);
                break;
            }
            guardY--;
            break;
        case Direction.Down:
            if (guardY + 1 >= map.Length)
            {
                shouldQuit = true;
                break;
            }
            if (map[guardY + 1][guardX] == '#')
            {
                guardDirection = TurnRight(guardDirection);
                break;
            }
            guardY++;
            break;
        case Direction.Left:
            if (guardX < 1)
            {
                shouldQuit = true;
                break;
            }
            if (map[guardY][guardX - 1] == '#')
            {
                guardDirection = TurnRight(guardDirection);
                break;
            }
            guardX--;
            break;
        case Direction.Right:
            if (guardX + 1 >= map[guardY].Length)
            {
                shouldQuit = true;
                break;
            }
            if (map[guardY][guardX + 1] == '#')
            {
                guardDirection = TurnRight(guardDirection);
                break;
            }
            guardX++;
            break;
    }
}

Console.WriteLine(guardVisited.Count);

Direction TurnRight(Direction direction)
{
    switch (direction)
    {
        case Direction.Up:
            return Direction.Right;
        case Direction.Down:
            return Direction.Left;
        case Direction.Left:
            return Direction.Up;
        case Direction.Right:
            return Direction.Down;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right,
}
