string[] lines = File.ReadAllLines("input");
Span<int> list1 = stackalloc int[lines.Length];
int list1Length = 0;
Span<int> list2 = stackalloc int[lines.Length];
int list2Length = 0;

foreach (var line in lines) {
    string[] strings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int i = Convert.ToInt32(strings[0]);
    int j = Convert.ToInt32(strings[1]);
    list1[list1Length++] = i;
    list2[list2Length++] = j;
}

list1.Sort();
list2.Sort();

int differenceSum = 0;

for (int i = 0; i < list1Length; i++) {
    int a = list1[i];
    int b = list2[i];
    int difference = Math.Abs(a - b);
    Console.WriteLine($"{a}\t{b}\t\t{difference}");
    differenceSum += difference;
}

Console.WriteLine(differenceSum);
