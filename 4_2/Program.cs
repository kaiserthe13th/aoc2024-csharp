char[][] board = File.ReadAllLines("input").Select(x => x.ToArray()).ToArray();

int count = 0;

for (int i = 0; i < board.Length; i++)
{
    for (int j = 0; j < board.Length; j++)
    {
        if (board[i][j] != 'A') continue;
        if (i < 1 || j < 1) continue;
        if (board.Length <= i + 1 || board[i + 1].Length <= j + 1) continue;
        if ((board[i - 1][j - 1] != 'M' || board[i + 1][j + 1] != 'S')
         && (board[i - 1][j - 1] != 'S' || board[i + 1][j + 1] != 'M')) continue;
        if ((board[i + 1][j - 1] != 'M' || board[i - 1][j + 1] != 'S')
         && (board[i + 1][j - 1] != 'S' || board[i - 1][j + 1] != 'M')) continue;
        count++;
    }
}

Console.WriteLine(count);
