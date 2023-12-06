namespace advent_of_code_2022;

public static class Day06
{
    public const string TestFileName = "Day06_test";
    public const string ProductionFileName = "Day06";

    public static long Part1(List<string> input)
    {
        var times = input[0].Split(':')[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToList();
        var distances = input[1].Split(':')[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToList();
        var races = times.Select((it, i) => new Race(it, distances[i]));

        return races.Select(it => it.CountPossibleWins()).Aggregate((acc, curr) => acc * curr);
    }

    public static long Part2(List<string> input)
    {
        var time = long.Parse(input[0].Split(':')[1].Trim().Replace(" ", ""));
        var distance = long.Parse(input[1].Split(':')[1].Trim().Replace(" ", ""));
        var race = new Race(time, distance);

        return race.CountPossibleWins();
    }

    private record Race(long Time, long Distance)
    {
        public long CountPossibleWins()
        {
            long n = 0;
            for (var i = 0; i <= Time; i++)
            {
                var speed = i;
                var finalDistance = speed * (Time - i);
                if (finalDistance > Distance) n++;
            }

            return n;
        }
    }
}