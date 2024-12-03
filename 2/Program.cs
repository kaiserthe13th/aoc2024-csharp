string[] levels = File.ReadAllLines("input");

int safeCount = 0;

foreach (string level in levels)
{
    int[] reports = level.Split().Select(x => Convert.ToInt32(x)).ToArray();
    Console.WriteLine(string.Join(", ", reports.Select(x => x.ToString()).ToArray()));

    bool isSafe = true;

    bool increasing = reports[1] > reports[0];
    for (int i = 0; i < reports.Length - 1; i++)
    {
        if (increasing)
        {
            if(reports[i] >= reports[i + 1] || reports[i + 1] - reports[i] > 3)
            {
                isSafe = false;
                break;
            }
        }
        else if (reports[i] <= reports[i + 1] || reports[i] - reports[i + 1] > 3)
        {
            isSafe = false;
            break;
        }
    }

    Console.WriteLine(isSafe);
    if (isSafe) safeCount++;
}

Console.WriteLine(safeCount);
