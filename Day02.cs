namespace advent_of_code_2022;

public static class Day02
{
    public const string TestFileName = "Day02_test";
    public const string ProductionFileName = "Day02";

    private static (int r, int g, int b) ParseHand(string hand)
    {
        var r = 0;
        var g = 0;
        var b = 0;
        foreach (var it in hand.Split(','))
        {
            var itSplit = it.Trim().Split(' ');
            switch (itSplit[1])
            {
                case "blue":
                    b = int.Parse(itSplit[0]);
                    break;

                case "green":
                    g = int.Parse(itSplit[0]);
                    break;

                case "red":
                    r = int.Parse(itSplit[0]);
                    break;
            }
        }

        return (r, g, b);
    }

    private static bool IsPossible((int r, int g, int b) hand)
    {
        var question = (r: 12, g: 13, b: 14);
        if (hand.r > question.r) return false;
        if (hand.g > question.g) return false;
        return hand.b <= question.b;
    }

    public static int Part1(List<string> input)
    {
        return input.Sum(row =>
        {
            var splitRow = row.Split(':');
            var id = int.Parse(splitRow[0].Split(' ')[1]);
            var hands = splitRow[1].Split(';').Select(ParseHand);
            return hands.All(IsPossible) ? id : 0;
        });
    }

    public static int Part2(List<string> input)
    {
        return input.Sum(row =>
        {
            var splitRow = row.Split(':');
            var hands = splitRow[1].Split(';').Select(ParseHand).ToList();
            var minR = hands.Where(it => it.r > 0).Max(it => it.r);
            var minG = hands.Where(it => it.g > 0).Max(it => it.g);
            var minB = hands.Where(it => it.b > 0).Max(it => it.b);
            return minR * minB * minG;
        });
    }
}