(long, long[])[] operations = File.ReadAllLines("input").Select(x => {
    string[] pair = x.Split(":", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    long result = Convert.ToInt64(pair[0]);
    long[] operands = pair[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => Convert.ToInt64(x)).ToArray();
    return (result, operands);
}).ToArray();

long sum = 0;

foreach (var operation in operations)
{
    for (int i = 0; i < (int)Math.Pow(3, operation.Item2.Length - 1); i++)
    {
        long result = operation.Item2[0];
        for (int j = 1; j < operation.Item2.Length; j++)
        {
            int comb = i / (int)Math.Pow(3, j - 1) % 3;
            if (comb == 0)
            {
                result += operation.Item2[j];
            }
            else if (comb == 1)
            {
                result *= operation.Item2[j];
            }
            else
            {
                result = Convert.ToInt64(result.ToString() + operation.Item2[j].ToString());
            }
        }
        if (result == operation.Item1)
        {
            sum += result;
            break;
        }
    }
}

Console.WriteLine(sum);
