using System.Text;

namespace advent_of_code_2022;

public static class Utils
{
    /// <summary>
    ///     Reads lines from the given input txt file.
    /// </summary>
    public static List<string> ReadInput(string name)
    {
        return File.ReadAllLines(Path.Combine("inputs", $"{name}.txt"), Encoding.UTF8).ToList();
    }

    public static int GetResult(string name)
    {
        return int.Parse(Environment.GetEnvironmentVariable(name) ?? "0");
    }

    public static string GetResultRaw(string name)
    {
        return Environment.GetEnvironmentVariable(name) ?? "";
    }
}