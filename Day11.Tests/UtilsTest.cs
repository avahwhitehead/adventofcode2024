using JetBrains.Annotations;

namespace Day11.Tests;

[TestSubject(typeof(Utils))]
public class UtilsTest
{
	[Theory]
	[InlineData("0 1 10 99 999", 0L, 1L, 10L, 99L, 999L)]
	[InlineData("0 1 10 99 999\n\r\n", 0L, 1L, 10L, 99L, 999L)]
	[InlineData("1 2024 1 0 9 9 2021976", 1L, 2024L, 1L, 0L, 9L, 9L, 2021976L)]
	[InlineData("125 17", 125L, 17L)]
	[InlineData(
		"2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2",
		2097446912L, 14168L, 4048L, 2L, 0L, 2L, 4L, 40L, 48L, 2024L, 40L, 48L, 80L, 96L, 2L, 8L, 6L, 7L, 6L, 0L, 3L, 2L
	)]
	public void Parse_Should_Produce_Correct_Array(string input, params long[] expected)
	{
		// Arrange

		// Act
		var actual = Utils.ParseInput(input);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, false)]
	[InlineData(9, false)]
	[InlineData(10, true)]
	[InlineData(99, true)]
	[InlineData(990, false)]
	[InlineData(995244, true)]
	[InlineData(7874631, false)]
	public void DoesNumberHaveEvenNumberOfDigits_Should_Produce_Correct_results(int value, bool expected)
	{
		// Arrange

		// Act
		var actual = Utils.DoesNumberHaveEvenNumberOfDigits(value);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1)]
	[InlineData(9, 1)]
	[InlineData(10, 2)]
	[InlineData(99, 2)]
	[InlineData(990, 3)]
	[InlineData(995244, 6)]
	[InlineData(7874631, 7)]
	public void GetNumberOfDigits_Should_Produce_Correct_results(int value, int expected)
	{
		/*
		 * Note: This will fail for value 0 and below.
		 * We do not have to worry about these values.
		 */

		// Arrange

		// Act
		var actual = Utils.GetNumberOfDigits(value);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(10, 1, 0)]
	[InlineData(99, 9, 9)]
	[InlineData(995244, 995, 244)]
	[InlineData(1000, 10, 0)]
	public void GetLeftHalfOfNumber_Should_Produce_Correct_results(int value, int expectedLeft, int expectedRight)
	{
		// Arrange
		var numberOfDigits = Utils.GetNumberOfDigits(value);

		// Act
		var actual = Utils.GetHalvesOfNumber(value, numberOfDigits);

		// Assert
		Assert.Equal(expectedLeft, actual.Left);
	}
}
