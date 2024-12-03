using System.Text.RegularExpressions;

int sum = 0;
bool mulEnabled = true;

string input = File.ReadAllText("input");
string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|do(n\'t)?\(\)";

foreach (Match m in Regex.Matches(input, pattern, RegexOptions.Multiline))
{
    if (m.Value.StartsWith("mul"))
    {
        if (mulEnabled)
        {
            int a = Convert.ToInt32(m.Groups[1].Value);
            int b = Convert.ToInt32(m.Groups[2].Value);
            sum += a * b;
        }
    }
    else if (m.Value.StartsWith("do"))
    {
        mulEnabled = !m.Value.StartsWith("don't");
    }
}

Console.WriteLine(sum);
