using Xunit;
using static advent_of_code_2022.Day02;

namespace advent_of_code_2022.tests;

public class Day02Tests
{
    [Fact]
    public void Part1_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY02_PART1"), Part1(input));
    }

    [Fact]
    public void Part2_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY02_PART2"), Part2(input));
    }
}