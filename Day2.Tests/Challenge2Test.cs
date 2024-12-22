using JetBrains.Annotations;
using Xunit;

namespace Day2.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge2();

		var input =
			"7 6 4 2 1\n" +
			"1 2 7 8 9\n" +
			"9 7 6 2 1\n" +
			"1 3 2 4 5\n" +
			"8 6 4 4 1\n" +
			"1 3 6 7 9\n";

		var inputArray = Utils.SplitInput(input);

		const int expected = 4;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Valid_Line_ShouldSucceed1()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [6, 9, 11, 12, 13, 16];

		const int expected = 1;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed1()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [6, 9, 13, 12, 13, 16];

		const int expected = 1;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed2()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [6, 9, 11, 12, 13, 20];

		const int expected = 1;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed3()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [6, 10, 11, 12, 13, 20];

		const int expected = 0;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed4()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [95, 92, 97, 99, 99];

		const int expected = 0;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed5()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [11, 11, 14, 16, 17];

		const int expected = 1;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed6()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [40, 40, 43, 45, 48, 50, 47];

		const int expected = 0;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed7()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [30, 40, 43, 45, 48, 50];

		const int expected = 1;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Single_Error_ShouldSucceed8()
	{
		// Arrange
		var sut = new Challenge2();

		int[] input = [46, 45, 47, 49, 51];

		const int expected = 1;

		// Act
		var actual = sut.Solve([input]);

		// Assert
		Assert.Equal(expected, actual);
	}
}
