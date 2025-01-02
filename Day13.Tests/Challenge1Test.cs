using JetBrains.Annotations;

namespace Day13.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_Should_Produce_Expected_Value()
	{
		// Arrange
		const string input =
			"Button A: X+94, Y+34\n" +
			"Button B: X+22, Y+67\n" +
			"Prize: X=8400, Y=5400\n" +
			"\n" +
			"Button A: X+26, Y+66\n" +
			"Button B: X+67, Y+21\n" +
			"Prize: X=12748, Y=12176\n" +
			"\n" +
			"Button A: X+17, Y+86\n" +
			"Button B: X+84, Y+37\n" +
			"Prize: X=7870, Y=6450\n" +
			"\n" +
			"Button A: X+69, Y+23\n" +
			"Button B: X+27, Y+71\n" +
			"Prize: X=18641, Y=10279\n";

		var inputArray = Utils.ParseInput(input);
		var sut = new Challenge1();

		const int expected = 480;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Example_Machine_1_Should_Produce_Expected_Values()
	{
		// Arrange
		var input = new PuzzleMachine(
			new Coord(94, 34),
			new Coord(22, 67),
			new Coord(8400, 5400)
		);

		var sut = new Challenge1();

		const int expectedCost = 280;
		const int expectedButtonAPresses = 80;
		const int expectedButtonBPresses = 40;

		// Act
		var actualCost = sut.FindMinimumCostToSolveMachine(input);
		var actualButtonPresses = sut.FindButtonPressesWithMinimumCostToSolveMachine(input);

		// Assert
		Assert.NotNull(actualCost);
		Assert.NotNull(actualButtonPresses);
		Assert.Equal(expectedCost, actualCost);
		Assert.Equal(expectedButtonAPresses, actualButtonPresses.Value.ButtonAPresses);
		Assert.Equal(expectedButtonBPresses, actualButtonPresses.Value.ButtonBPresses);
	}

	[Fact]
	public void Example_Machine_2_Should_Produce_Expected_Values()
	{
		// Arrange
		var input = new PuzzleMachine(
			new Coord(26, 66),
			new Coord(67, 21),
			new Coord(12748, 12176)
		);

		var sut = new Challenge1();

		// Act
		var actualCost = sut.FindMinimumCostToSolveMachine(input);
		var actualButtonPresses = sut.FindButtonPressesWithMinimumCostToSolveMachine(input);

		// Assert
		Assert.Null(actualCost);
		Assert.Null(actualButtonPresses);
	}

	[Fact]
	public void FindMinimumCostToSolveMachine_Example_Machine_3_Should_Produce_Expected_Value()
	{
		// Arrange
		var input = new PuzzleMachine(
			new Coord(17, 86),
			new Coord(84, 37),
			new Coord(7870, 6450)
		);

		var sut = new Challenge1();

		const int expectedCost = 200;
		const int expectedButtonAPresses = 38;
		const int expectedButtonBPresses = 86;

		// Act
		var actualCost = sut.FindMinimumCostToSolveMachine(input);
		var actualButtonPresses = sut.FindButtonPressesWithMinimumCostToSolveMachine(input);

		// Assert
		Assert.NotNull(actualCost);
		Assert.NotNull(actualButtonPresses);
		Assert.Equal(expectedCost, actualCost);
		Assert.Equal(expectedButtonAPresses, actualButtonPresses.Value.ButtonAPresses);
		Assert.Equal(expectedButtonBPresses, actualButtonPresses.Value.ButtonBPresses);
	}

	[Fact]
	public void FindMinimumCostToSolveMachine_Example_Machine_4_Should_Produce_Expected_Value()
	{
		// Arrange
		var input = new PuzzleMachine (
			new Coord(69, 23),
			new Coord(27, 71),
			new Coord(18641, 10279)
		);

		var sut = new Challenge1();

		// Act
		var actualCost = sut.FindMinimumCostToSolveMachine(input);
		var actualButtonPresses = sut.FindButtonPressesWithMinimumCostToSolveMachine(input);

		// Assert
		Assert.Null(actualCost);
		Assert.Null(actualButtonPresses);
	}
}
