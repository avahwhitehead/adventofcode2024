using JetBrains.Annotations;

namespace Day11.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_Should_Produce_Expected_Value()
	{
		// Arrange
		var input = "125 17\n";

		var inputArray = Utils.ParseInput(input);
		var sut = new Challenge1(inputArray);

		const int expected = 55312;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Step_Should_Produce_Expected_Values()
	{
		// Arrange
		var startArray = Utils.ParseInput("125 17\n");

		var sut = new Challenge1(startArray);

		// Act
		// Assert

		sut.StepStones();
		long[] expected = [253000, 1, 7];
		Assert.Equal(expected, sut.Stones);

		sut.StepStones();
		expected = [253, 0, 2024, 14168];
		Assert.Equal(expected, sut.Stones);

		sut.StepStones();
		expected = [512072, 1, 20, 24, 28676032];
		Assert.Equal(expected, sut.Stones);

		sut.StepStones();
		expected = [512, 72, 2024, 2, 0, 2, 4, 2867, 6032];
		Assert.Equal(expected, sut.Stones);

		sut.StepStones();
		expected = [1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32];
		Assert.Equal(expected, sut.Stones);

		sut.StepStones();
		expected = [2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2];
		Assert.Equal(expected, sut.Stones);
	}
}
