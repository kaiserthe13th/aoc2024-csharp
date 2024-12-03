string[] lines = File.ReadAllLines("input");
Span<int> list1 = stackalloc int[lines.Length];
int list1Length = 0;
Span<int> list2 = stackalloc int[lines.Length];
int list2Length = 0;
Dictionary<int, int> nCounters = new Dictionary<int, int>(lines.Length);

foreach (var line in lines) {
    string[] strings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int i = Convert.ToInt32(strings[0]);
    int j = Convert.ToInt32(strings[1]);
    list1[list1Length++] = i;
    list2[list2Length++] = j;
}

foreach (int i in list2) {
    int hasValue = 0;
    nCounters.TryGetValue(i, out hasValue);
    nCounters.Remove(i);
    nCounters.Add(i, ++hasValue);
}

int sum = 0;

foreach (int i in list1) {
    sum += i * nCounters.GetValueOrDefault(i);
}

Console.WriteLine(sum);
