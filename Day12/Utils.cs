namespace Day12;

public static class Utils
{
	public static string[] ParseInput(string input)
	{
		return input.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
	}
}
