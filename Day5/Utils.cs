namespace Day5;

public static class Utils
{
	public static ((int DependencyPage, int DependentPage)[] Requirements, int[][] PageLists) Parse(string input)
	{
		var lines = input.Trim('\n').Split('\n');

		var requirements = new List<(int DependencyPage, int DependentPage)>();

		var lineIndex = 0;
		while (lines[lineIndex] != "")
		{
			var pages = lines[lineIndex]
				.Split('|')
				.Select(int.Parse)
				.ToArray();

			requirements.Add((pages[0], pages[1]));

			lineIndex++;
		}

		var pageLists = lines
			.Skip(lineIndex)
			.Skip(1)
			.Select(line => line.Split(",").Select(int.Parse).ToArray());

		return (requirements.ToArray(), pageLists.ToArray());
	}
}
