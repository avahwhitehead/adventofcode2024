using JetBrains.Annotations;

namespace Day14.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_Should_Produce_Expected_Value()
	{
		// Arrange
		const string input =
			"p=0,4 v=3,-3\n" +
			"p=6,3 v=-1,-3\n" +
			"p=10,3 v=-1,2\n" +
			"p=2,0 v=2,-1\n" +
			"p=0,0 v=1,3\n" +
			"p=3,0 v=-2,-2\n" +
			"p=7,6 v=-1,-3\n" +
			"p=3,0 v=-1,-2\n" +
			"p=9,3 v=2,3\n" +
			"p=7,3 v=-1,2\n" +
			"p=2,4 v=2,-3\n" +
			"p=9,5 v=-3,-3\n";

		var inputArray = Utils.ParseInput(input);
		var sut = new Challenge1(11, 7);

		const int expected = 12;

		// Act
		var actual = sut.Solve(inputArray, 100);

		// Assert
		Assert.Equal(expected, actual);
	}
}
