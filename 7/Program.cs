(long, long[])[] operations = File.ReadAllLines("input").Select(x => {
    string[] pair = x.Split(":", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    long result = Convert.ToInt64(pair[0]);
    long[] operands = pair[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => Convert.ToInt64(x)).ToArray();
    return (result, operands);
}).ToArray();

long sum = 0;

foreach (var operation in operations)
{
    for (int i = 0; i < (int)Math.Pow(2, operation.Item2.Length - 1); i++)
    {
        long result = operation.Item2[0];
        // Console.Write(result);
        for (int j = 1; j < operation.Item2.Length; j++)
        {
            if (((i >> (j - 1)) & 1) > 0)
            {
                // Console.Write("*");
                result *= operation.Item2[j];
            }
            else
            {
                // Console.Write("+");
                result += operation.Item2[j];
            }
            // Console.Write(operation.Item2[j]);
        }
        // Console.WriteLine();
        if (result == operation.Item1)
        {
            // Console.WriteLine("Found");
            sum += result;
            break;
        }
    }
}

Console.WriteLine(sum);
