namespace Day11;

public static class Utils
{
	public static long[] ParseInput(string input)
	{
		return input
			.Trim('\n', '\r', ' ')
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(long.Parse)
			.ToArray();
	}

	public static bool DoesNumberHaveEvenNumberOfDigits(long number)
	{
		return number.ToString().Length % 2 == 0;
	}

	public static long GetLeftHalfOfNumber(long number)
	{
		var str = number.ToString();
		str = str.Substring(0, str.Length / 2);
		return long.Parse(str);
	}

	public static long GetRightHalfOfNumber(long number)
	{
		var str = number.ToString();
		str = str.Substring(str.Length / 2);
		return long.Parse(str);
	}
}
