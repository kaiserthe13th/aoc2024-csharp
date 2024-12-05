string lines = File.ReadAllText("input");

StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

(int, int)[] rules = lines.Split(Environment.NewLine + Environment.NewLine, options)[0].Split(Environment.NewLine, options).Select(static x =>
{
    var a = x.Split("|").Select(x => Convert.ToInt32(x)).ToArray();
    return (a[0], a[1]);
}).ToArray();
int[][] lists = lines
    .Split(Environment.NewLine + Environment.NewLine, options)[1]
    .Split(Environment.NewLine, options)
    .Select(x => x
        .Split(',', options)
        .Select(x => Convert.ToInt32(x))
        .ToArray())
    .ToArray();

int sum = 0;

foreach (var list in lists)
{
    bool isCorrect = true;

    foreach ((int first, int second) in rules)
    {
        int firstIndex = Array.IndexOf(list, first);
        int secondIndex = Array.IndexOf(list, second);
        if (firstIndex == -1 || secondIndex == -1) continue;
        if (firstIndex >= secondIndex)
        {
            isCorrect = false;
            break;
        }
    }

    if (!isCorrect) continue;

    sum += list[list.Length / 2];
}

Console.WriteLine(sum);
