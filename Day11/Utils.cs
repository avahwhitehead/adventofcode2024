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

	public static int GetNumberOfDigits(long number)
	{
		return (int)Math.Floor(Math.Log10(number)) + 1;
	}

	public static bool DoesNumberHaveEvenNumberOfDigits(long number)
	{
		return GetNumberOfDigits(number) % 2 == 0;
	}

	public static (long Left, long Right) GetHalvesOfNumber(long number, int numberOfDigits)
	{
		var digits = numberOfDigits;

		var pow = (long)Math.Pow(10, digits >> 1);

		var rightHalf = number % pow;
		var leftHalf = (number - rightHalf) / pow;

		return (leftHalf, rightHalf);
	}
}
