using dotenv.net;
using Xunit;
using static advent_of_code_2022.Day05;

namespace advent_of_code_2022.tests;

public class Day05Tests
{
    public Day05Tests()
    {
        DotEnv.Load();
    }

    [Fact]
    public void Part1_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY05_PART1"), Part1(input));
    }

    [Fact(Skip = "slow")]
    public void Part2_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY05_PART2"), Part2(input));
    }
}