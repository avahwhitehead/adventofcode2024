using JetBrains.Annotations;
using Xunit;

namespace Day2.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge1();

		var input =
			"7 6 4 2 1\n" +
			"1 2 7 8 9\n" +
			"9 7 6 2 1\n" +
			"1 3 2 4 5\n" +
			"8 6 4 4 1\n" +
			"1 3 6 7 9\n";

		var inputArray = Utils.SplitInput(input);

		const int expected = 2;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}
}
