char[][] board = File.ReadAllLines("input").Select(x => x.ToArray()).ToArray();

int count = 0;

for (int i = 0; i < board.Length; i++)
{
    for (int j = 0; j < board.Length; j++)
    {
        bool isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board[i].Length <= j + k || board[i][j + k] != "XMAS"[k]) isXmas = false;
        if (isXmas) count++;

        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board.Length <= i + k || board[i + k][j] != "XMAS"[k]) isXmas = false;
        if (isXmas) count++;
        
        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board[i].Length <= j + k || board[i][j + k] != "SAMX"[k]) isXmas = false;
        if (isXmas) count++;
        
        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board.Length <= i + k || board[i + k][j] != "SAMX"[k]) isXmas = false;
        if (isXmas) count++;
        
        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board.Length <= i + k || board[i + k].Length <= j + k || board[i + k][j + k] != "XMAS"[k]) isXmas = false;
        if (isXmas) count++;
        
        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board.Length <= i + k || board[i + k].Length <= j + k || board[i + k][j + k] != "SAMX"[k]) isXmas = false;
        if (isXmas) count++;
        
        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board.Length <= i + k || 0 > j - k || board[i + k][j - k] != "XMAS"[k]) isXmas = false;
        if (isXmas) count++;
        
        isXmas = true;
        for (int k = 0; k < 4; k++)
            if (board.Length <= i + k || 0 > j - k || board[i + k][j - k] != "SAMX"[k]) isXmas = false;
        if (isXmas) count++;
    }
}

Console.WriteLine(count);
