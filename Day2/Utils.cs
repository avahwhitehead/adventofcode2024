namespace Day2;

public class Utils
{
	public static int[][] SplitInput(string input)
	{
		var lines = input.Split(["\r", "\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

		var result = new int[lines.Length][];
		for (var i = 0; i < lines.Length; i++)
		{
			var line = lines[i];

			var lineNumbers = line
				.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
				.Select(int.Parse)
				.ToArray();

			result[i] = lineNumbers;
		}

		return result;
	}
}
