using System.Text.RegularExpressions;

namespace Day3;

public partial class Challenge2
{
	public int Solve(string input)
	{
		// Get the list of ranges determining which statements are active
		var dosAndDonts = FindDosAndDonts(input);
		var conditionRanges = GetRanges(dosAndDonts);

		// Get all the multiplication statements
		var multiplications = FindMuls(input);

		var sum = 0;

		var multiplicationIndex = 0;
		foreach (var range in conditionRanges)
		{
			while (multiplicationIndex < multiplications.Count)
			{
				var currentMul = multiplications[multiplicationIndex];
				if (currentMul.Index > range.EndIndex)
				{
					// Consider this mul as part of the next range
					break;
				}

				// Only calculate enabled statements
				if (range.IsDo)
				{
					sum += currentMul.Left * currentMul.Right;
				}
				multiplicationIndex++;
			}
		}

		return sum;
	}

	public List<(int Index, int Left, int Right)> FindMuls(string input)
	{
		var matches = MulRegex().Matches(input);

		var res = new List<(int Index, int Left, int Right)>();
		foreach (Match match in matches)
		{
			var valA = match.Groups[1].Value;
			var valB = match.Groups[2].Value;

			res.Add((match.Index, int.Parse(valA), int.Parse(valB)));
		}

		return res;
	}

	public List<(int Index, bool IsDo)> FindDosAndDonts(string input)
	{
		var matches = DoDontRegex().Matches(input);

		var res = new List<(int Index, bool IsDo)>();
		foreach (Match match in matches)
		{
			var index = match.Index;

			var functionName = match.Groups[1].Value;
			var isDo = functionName == "do";

			res.Add((index, isDo));
		}

		return res;
	}

	public List<(int StartIndex, int EndIndex, bool IsDo)> GetRanges(IEnumerable<(int Index, bool IsDo)> dosAndDonts)
	{
		var ranges = new List<(int StartIndex, int EndIndex, bool IsDo)>();

		var indexStart = 0;
		var currentState = true;

		foreach (var condition in dosAndDonts)
		{
			if (condition.IsDo == currentState) continue;

			ranges.Add((indexStart, condition.Index - 1, currentState));
			indexStart = condition.Index;
			currentState = condition.IsDo;
		}

		ranges.Add((indexStart, int.MaxValue, currentState));

		return ranges;
	}

	[GeneratedRegex(@"mul\((\d+),(\d+)\)")]
	private static partial Regex MulRegex();

	[GeneratedRegex(@"(do(?:n't)?)\(\)")]
	private static partial Regex DoDontRegex();
}
