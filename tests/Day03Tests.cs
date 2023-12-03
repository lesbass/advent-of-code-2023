using Xunit;
using static advent_of_code_2022.Day03;

namespace advent_of_code_2022.tests;

public class Day03Tests
{
    [Fact]
    public void Part1_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY03_PART1"), Part1(input));
    }

    [Fact]
    public void Part2_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY03_PART2"), Part2(input));
    }
}