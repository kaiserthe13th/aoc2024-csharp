string[] levels = File.ReadAllLines("input");

int safeCount = 0;

bool IsSafe(int[] reports, bool didRemove = false)
{
    bool increasing = reports[1] > reports[0];
    for (int i = 0; i < reports.Length - 1; i++)
    {
        if (increasing)
        {
            if (reports[i] >= reports[i + 1] || reports[i + 1] - reports[i] > 3)
            {
                if (didRemove)
                {
                    return false;
                }
                // copy reports except reports[i-1]
                int[] a = reports.Select((x, idx) => (x, idx)).Where(x => x.Item2 != i - 1).Select(x => x.Item1).ToArray();
                if (IsSafe(a, true))
                {
                    Console.WriteLine($"removed [{i-1}]");
                    return true;
                }
                // copy reports except reports[i]
                a = reports.Select((x, idx) => (x, idx)).Where(x => x.Item2 != i).Select(x => x.Item1).ToArray();
                if (IsSafe(a, true))
                {
                    Console.WriteLine($"removed [{i}]");
                    return true;
                }
                // copy reports except reports[i+1]
                a = reports.Select((x, idx) => (x, idx)).Where(x => x.Item2 != i + 1).Select(x => x.Item1).ToArray();
                if (IsSafe(a, true))
                {
                    Console.WriteLine($"removed [{i + 1}]");
                    return true;
                }
                return false;
            }
        }
        else if (reports[i] <= reports[i + 1] || reports[i] - reports[i + 1] > 3)
        {
            if (didRemove)
            {
                return false;
            }
            // copy reports except reports[i-1]
            int[] a = reports.Select((x, idx) => (x, idx)).Where(x => x.Item2 != i - 1).Select(x => x.Item1).ToArray();
            if (IsSafe(a, true))
            {
                Console.WriteLine($"removed [{i-1}]");
                return true;
            }
            // copy reports except reports[i]
            a = reports.Select((x, idx) => (x, idx)).Where(x => x.Item2 != i).Select(x => x.Item1).ToArray();
            if (IsSafe(a, true))
            {
                Console.WriteLine($"removed [{i + 1}]");
                return true;
            }
            // copy reports except reports[i+1]
            a = reports.Select((x, idx) => (x, idx)).Where(x => x.Item2 != i + 1).Select(x => x.Item1).ToArray();
            if (IsSafe(a, true))
            {
                Console.WriteLine($"removed [{i + 1}]");
                return true;
            }
            return false;
        }
    }

    return true;
}

foreach (string level in levels)
{
    int[] reports = level.Split().Select(x => Convert.ToInt32(x)).ToArray();

    bool isSafe = IsSafe(reports);

    if (isSafe) safeCount++;
}

Console.WriteLine(safeCount);
