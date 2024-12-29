namespace Day10;

public static class Utils
{
	public static int[][] ParseInput(string input)
	{
		return input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(row =>
				row.ToCharArray()
					.Select(c => int.Parse(c.ToString()))
					.ToArray()
			).ToArray();
	}
}
