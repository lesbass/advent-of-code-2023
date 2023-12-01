using Xunit;
using static advent_of_code_2022.Day01;

namespace advent_of_code_2022.tests;

public class Day01Tests
{
    [Fact]
    public void Part1_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY01_PART1"), Part1(input));
    }

    [Fact]
    public void Part2_Test()
    {
        var input = Utils.ReadInput(ProductionFileName);

        Assert.Equal(Utils.GetResult("DAY01_PART2"), Part2(input));
    }
}