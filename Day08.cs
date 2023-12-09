namespace advent_of_code_2022;

public static class Day08
{
    public const string TestFileName = "Day08_test";
    public const string ProductionFileName = "Day08";

    public static int Part1(List<string> input)
    {
        var path = input[0].Select(it => it.ToString()).ToList();
        var map = input.Skip(2).ToDictionary(
            it => it.Split('=')[0].Trim(),
            it => it.Split('=')[1].Replace("(", "").Replace(")", "").Split(',').Select(x => x.Trim())
                .ToList());

        var steps = 0;
        var current = "AAA";

        while (current != "ZZZ")
        {
            var currentStep = path[steps % path.Count];
            var currentPath = map[current];
            if (currentStep == "L")
                current = currentPath[0];
            else
                current = currentPath[1];

            steps++;
        }

        return steps;
    }

    public static int Part2(List<string> input)
    {
        var path = input[0].Select(it => it.ToString()).ToList();
        var map = input.Skip(2).ToDictionary(
            it => it.Split('=')[0].Trim(),
            it => it.Split('=')[1].Replace("(", "").Replace(")", "").Split(',').Select(x => x.Trim())
                .ToList());

        var steps = 0;
        var currentNodes = map.Keys.Where(it => it.EndsWith('A')).ToList();

        while (!currentNodes.All(it => it.EndsWith('Z')))
        {
            var currentStep = path[steps % path.Count];
            currentNodes = currentNodes.Select(current =>
            {
                var currentPath = map[current];
                return currentPath[currentStep == "L" ? 0 : 1];
            }).Distinct().ToList();

            steps++;
        }

        return steps;
    }
}