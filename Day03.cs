namespace advent_of_code_2022;

public static class Day03
{
    public const string TestFileName = "Day03_test";
    public const string ProductionFileName = "Day03";

    private static List<Symbol> GetSymbols(List<string> input)
    {
        return input.SelectMany((row, y) =>
                row.Select((c, x) => c == '.' || char.IsNumber(c) ? null : new Symbol(x, y, c == '*')))
            .Where(it => it is not null)
            .Select(it => it!)
            .ToList();
    }

    private static (string row, string[] numbers) ExtractNumbers(string input)
    {
        var row = string.Join("", input
            .Select(c => char.IsNumber(c) ? c : '.'));

        return (row, row
            .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public static int Part1(List<string> input)
    {
        var validNumbers = new List<int>();
        var symbols = GetSymbols(input);
        for (var y = 0; y < input.Count; y++)
        {
            var (row, numbers) = ExtractNumbers(input[y]);

            var cursor = 0;
            foreach (var number in numbers)
            {
                var hasSymbolNearby = false;

                var startX = row.Substring(cursor).IndexOf(number, StringComparison.Ordinal) + cursor;
                var endX = startX + number.Length;
                cursor = endX;

                for (var currY = y - 1; currY <= y + 1; currY++)
                for (var currX = startX - 1; currX <= endX; currX++)
                    if (!hasSymbolNearby && symbols.Any(it => it.X == currX && it.Y == currY))
                        hasSymbolNearby = true;

                if (hasSymbolNearby) validNumbers.Add(int.Parse(number));
            }
        }

        return validNumbers.Sum();
    }

    public static int Part2(List<string> input)
    {
        var symbols = GetSymbols(input);
        for (var y = 0; y < input.Count; y++)
        {
            var (row, numbers) = ExtractNumbers(input[y]);

            var cursor = 0;
            foreach (var number in numbers)
            {
                var startX = row.Substring(cursor).IndexOf(number, StringComparison.Ordinal) + cursor;
                var endX = startX + number.Length;
                cursor = endX;

                var alreadySeenSymbols = new HashSet<Symbol>();
                for (var currY = y - 1; currY <= y + 1; currY++)
                for (var currX = startX - 1; currX <= endX; currX++)
                {
                    var adjacentSymbol = symbols.FirstOrDefault(it => it.X == currX && it.Y == currY);
                    if (adjacentSymbol?.IsGear is true && !alreadySeenSymbols.Contains(adjacentSymbol))
                    {
                        alreadySeenSymbols.Add(adjacentSymbol);
                        adjacentSymbol.AdjacentNumbers++;
                        adjacentSymbol.Ratio *= int.Parse(number);
                    }
                }
            }
        }

        return symbols.Sum(it => it is { IsGear: true, AdjacentNumbers: 2 } ? it.Ratio : 0);
    }

    private record Symbol(int X, int Y, bool IsGear)
    {
        public int AdjacentNumbers { get; set; }
        public int Ratio { get; set; } = 1;
    }
}