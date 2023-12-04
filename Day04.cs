namespace advent_of_code_2022;

public static class Day04
{
    public const string TestFileName = "Day04_test";
    public const string ProductionFileName = "Day04";

    private static int GetMatchingNumbers(string card)
    {
        var columns = card.Split(':')[1].Split('|');
        var myNumbers = columns[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(it => !string.IsNullOrEmpty(it.Trim()))
            .Select(it => int.Parse(it.Trim())).ToList();
        var winningNumbers = columns[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(it => !string.IsNullOrEmpty(it.Trim()))
            .Select(it => int.Parse(it.Trim())).ToList();

        return myNumbers.Count(it => winningNumbers.Contains(it));
    }

    public static int Part1(List<string> input)
    {
        return input.Sum(GetCardPoints);
    }

    public static int Part2(List<string> input)
    {
        return GetCards(input, input);
    }

    private static int GetCards(IReadOnlyList<string> input, IReadOnlyCollection<string> allData)
    {
        return input.Select(GetMoreCards(allData)).Sum() + input.Count;
    }

    private static Func<string, int, int> GetMoreCards(IEnumerable<string> allData)
    {
        return (card, currentIndex) =>
        {
            var points = GetMatchingNumbers(card);
            var nextCards = allData.Skip(currentIndex + 1).ToList();
            var newCards = nextCards.Take(points).ToList();
            return GetCards(newCards, nextCards);
        };
    }

    private static int GetCardPoints(string card)
    {
        var wins = GetMatchingNumbers(card);
        if (wins == 0) return 0;
        return (int)Math.Pow(2, wins - 1);
    }
}