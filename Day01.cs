namespace advent_of_code_2022;

public static class Day01
{
    public const string TestFileName = "Day01_test";
    public const string ProductionFileName = "Day01";

    public static int Part1(List<string> input)
    {
        return input.Sum(it =>
        {
            var digits = it.Where(c => int.TryParse(c.ToString(), out _)).Select(c => int.Parse(c.ToString())).ToList();
            if (!digits.Any()) return 0;
            var first = digits.First();
            var last = digits.Last();
            return int.Parse($"{first}{last}");
        });
    }

    public static int Part2(List<string> input)
    {
        var digitList = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        return input.Sum(it =>
        {
            var digits = it.Select((c, i) => int.TryParse(c.ToString(), out var n) ? (n, i) : (c, -1))
                .Where(c => c.i >= 0).ToList();
            for (var i = 0; i < it.Length; i++)
                digits.AddRange(digitList.Select(c => (n: c.Value, i: it.Substring(i).StartsWith(c.Key) ? i : -1))
                    .Where(c => c.i >= 0));

            if (!digits.Any()) return 0;
            var first = digits.MinBy(c => c.i).n;
            var last = digits.MaxBy(c => c.i).n;
            return int.Parse($"{first}{last}");
        });
    }
}