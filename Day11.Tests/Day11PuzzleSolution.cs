using Xunit.Abstractions;

namespace Day11.Tests;

public class Day11PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day11.txt";

	private long[] GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return Utils.ParseInput(fileContent);
	}

	[Fact]
	public void Challenge1()
	{
		// Arrange
		var inputData = GetInput();

		var sut = new Challenge1(inputData);

		// Act
		var actualResult = sut.Solve();

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}

	[Fact]
	public void Challenge2()
	{
		// Arrange
		var inputData = GetInput();

		var sut = new Challenge2(inputData);

		// Act
		var steps = 75;
		for (var i = 0; i < steps; i++)
		{
			sut.StepStones();
			var stoneCount = sut.StonesCount;
			_testOutputHelper.WriteLine($"{DateTime.Now} - step {i + 1}/{steps} stones: {stoneCount}");
		}

		// Assert
		_testOutputHelper.WriteLine($"Result: {sut.StonesCount}");
	}
}
