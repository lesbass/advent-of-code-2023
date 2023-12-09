namespace advent_of_code_2022;

public static class Day09
{
    public const string TestFileName = "Day09_test";
    public const string ProductionFileName = "Day09";

    private static int ProcessHistory(List<int> data)
    {
        var current = data[0];
        var newData = data.Skip(1).Select(it =>
        {
            var next = current - it;
            current = it;
            return next;
        }).ToList();

        var distinctNewData = newData.Distinct().ToList();

        var sumValue = distinctNewData.Count == 1 ? distinctNewData.First() : ProcessHistory(newData);
        return data[0] + sumValue;
    }

    public static int Part1(List<string> input)
    {
        return input
            .Select(it => it.Split(' ').Select(int.Parse).Reverse().ToList())
            .Sum(ProcessHistory);
    }

    public static int Part2(List<string> input)
    {
        return input
            .Select(it => it.Split(' ').Select(int.Parse).ToList())
            .Sum(ProcessHistory);
    }
}