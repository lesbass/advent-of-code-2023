namespace advent_of_code_2022;

public static class Day05
{
    public const string TestFileName = "Day05_test";
    public const string ProductionFileName = "Day05";

    public static long Part1(List<string> input)
    {
        var seeds = input[0].Split(':')[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(it => long.Parse(it.Trim()));

        var converters = GetConverters(input);
        return GetMinLocation(seeds.ToList(), converters);
    }

    public static long Part2(List<string> input)
    {
        var seeds = input[0].Split(':')[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(it => long.Parse(it.Trim())).ToList();

        var converters = GetConverters(input);
        converters.Reverse();

        var ranges = new List<(long start, long end)>();
        for (var i = 0; i < seeds.Count; i += 2) ranges.Add((seeds[i], seeds[i] + seeds[i + 1]));

        for (long min = 0;; min++)
        {
            var current = min;
            foreach (var converter in converters) current = converter.Revert(current);

            if (ranges.Any(it => it.start <= current && it.end > current)) return min;
        }
    }

    private static long GetMinLocation(List<long> seeds, List<Converter> converters)
    {
        var locations = seeds.Select(it => GetMinLocation(converters, it));

        return locations.Min();
    }

    private static long GetMinLocation(List<Converter> converters, long it)
    {
        var current = it;
        foreach (var converter in converters) current = converter.Convert(current);

        return current;
    }

    private static List<Converter> GetConverters(List<string> input)
    {
        var converters = new List<Converter>();
        var currentConverter = new Converter();
        foreach (var row in input.Skip(2))
        {
            if (string.IsNullOrEmpty(row))
            {
                converters.Add(currentConverter);
                currentConverter = new Converter();
            }

            var rowSplit = row.Split(' ');
            if (long.TryParse(rowSplit[0], out _))
                currentConverter.AddRange(long.Parse(rowSplit[0]), long.Parse(rowSplit[1]), long.Parse(rowSplit[2]));
        }

        converters.Add(currentConverter);
        return converters;
    }

    private class Converter
    {
        private List<Range> Ranges { get; } = new();

        public void AddRange(long destinationStart, long sourceStart, long rangeLength)
        {
            Ranges.Add(new Range
                { DestinationStart = destinationStart, SourceStart = sourceStart, RangeLength = rangeLength });
        }

        public long Convert(long source)
        {
            foreach (var range in Ranges)
                if (source >= range.SourceStart && source < range.SourceStart + range.RangeLength)
                    return range.DestinationStart + (source - range.SourceStart);

            return source;
        }

        public long Revert(long destination)
        {
            foreach (var range in Ranges)
                if (destination >= range.DestinationStart && destination < range.DestinationStart + range.RangeLength)
                    return range.SourceStart + (destination - range.DestinationStart);

            return destination;
        }

        private class Range
        {
            public long DestinationStart { get; set; }
            public long SourceStart { get; set; }
            public long RangeLength { get; set; }
        }
    }
}