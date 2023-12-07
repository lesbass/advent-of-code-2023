using dotenv.net;
using Xunit;
using static advent_of_code_2022.Day07;

namespace advent_of_code_2022.tests;

public class Day07Tests
{
    public Day07Tests()
    {
        DotEnv.Load();
    }

    [Fact]
    public void Part1_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY07_PART1"), Part1(input));
    }

    [Fact]
    public void Part2_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY07_PART2"), Part2(input));
    }
}