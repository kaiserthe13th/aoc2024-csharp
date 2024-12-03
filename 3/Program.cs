using System.Text.RegularExpressions;

int sum = 0;

string input = File.ReadAllText("input");
string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

foreach (Match m in Regex.Matches(input, pattern, RegexOptions.Multiline))
{
    int a = Convert.ToInt32(m.Groups[1].Value);
    int b = Convert.ToInt32(m.Groups[2].Value);
    sum += a * b;
}

Console.WriteLine(sum);
