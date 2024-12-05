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
    Console.WriteLine("---------------");

    bool wasCorrect;
    bool firstCorrect = true;
    do
    {
        wasCorrect = Reorder(list, rules);
        if (!wasCorrect) firstCorrect = false;
    } while (!wasCorrect);

    if (firstCorrect) continue;

    sum += list[list.Length / 2];
}

Console.WriteLine(sum);

bool Reorder(int[] list, (int, int)[] rules)
{
    bool wasCorrect = true;

    foreach ((int first, int second) in rules)
    {
        int firstIndex = Array.IndexOf(list, first);
        int secondIndex = Array.IndexOf(list, second);
        if (firstIndex == -1 || secondIndex == -1) continue;
        if (firstIndex >= secondIndex)
        {
            wasCorrect = false;
            int temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
            Console.WriteLine($"{first}|{second}: [{firstIndex}] swap [{secondIndex}]");
        }
    }

    return wasCorrect;
}
