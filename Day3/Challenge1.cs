using System.Text.RegularExpressions;

namespace Day3;

public partial class Challenge1
{
	public int Solve(string input)
	{
		return FindMuls(input)
			.Select(tuple => tuple.Left * tuple.Right).Sum();
	}

	public List<(int Left, int Right)> FindMuls(string input)
	{
		var matches = MulRegex().Matches(input);

		var res = new List<(int Left, int Right)>();
		foreach (Match match in matches)
		{
			var valA = match.Groups[1].Value;
			var valB = match.Groups[2].Value;

			res.Add((int.Parse(valA), int.Parse(valB)));
		}

		return res;
	}

    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex MulRegex();
}
