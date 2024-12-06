string[] map = File.ReadAllLines("input");

bool shouldBreak = false;
int initialX = 0, initialY = 0;
for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map.Length; j++)
    {
        if (map[i][j] == '^')
        {
            initialY = i;
            initialX = j;
            shouldBreak = true;
            break;
        }
    }
    if (shouldBreak) break;
}

int count = 0;

for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map.Length; j++)
    {
        if (map[i][j] == '^' || map[i][j] == '#') continue;
        string[] nmap = new string[map.Length];
        map.CopyTo(nmap, 0);
        nmap[i] = nmap[i].Substring(0, j) + "#" + nmap[i].Substring(j + 1);
        if (HasInfiniteLoop(nmap)) count++;
    }
}

Console.WriteLine(count);

bool HasInfiniteLoop(string[] map) {
    int guardX = initialX;
    int guardY = initialY;
    Direction guardDirection = Direction.Up;
    
    HashSet<(int, int)> guardVisited = new();
    var visitDirections = new Direction[map.Length, map[0].Length];

    while (true)
    {
        _ = guardVisited.Add((guardX, guardY));
        if ((visitDirections[guardY, guardX] & guardDirection) > 0)
        {
            return true;
        }
        visitDirections[guardY, guardX] |= guardDirection;
        switch (guardDirection)
        {
            case Direction.Up:
                if (guardY < 1)
                {
                    return false;
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
                    return false;
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
                    return false;
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
                    return false;
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
}

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
    Up = 1,
    Down = 2,
    Left = 4,
    Right = 8,
}
