using Xunit.Abstractions;

namespace Day14.Tests;

public class Day14PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day14.txt";

	private Robot[] GetInput()
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

		var sut = new Challenge1(101, 103);

		// Act
		var actualResult = sut.Solve(inputData, 100);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}

	private const string PathToDay14OutputFile = "/tmp/xmas.txt";

	[Fact]
	public void Challenge2_Write_To_File()
	{
		// Arrange
		var inputData = GetInput();
		var sut = new Challenge2(101, 103);

		// Act
		var stepCount = 89;
		sut.Step(inputData, stepCount);

		File.Delete(PathToDay14OutputFile);
		const int stepIncrement = 101;
		do
		{
			var drawRobots = sut.DrawRobots(inputData);
			_testOutputHelper.WriteLine(drawRobots);
			File.AppendAllText(PathToDay14OutputFile, "Steps: " + stepCount + "\n");
			File.AppendAllText(PathToDay14OutputFile, drawRobots);
			File.AppendAllText(PathToDay14OutputFile, "\n");

			sut.Step(inputData, stepIncrement);
			stepCount += stepIncrement;
		} while (stepCount < 10_000);
	}

	[Fact]
	public void Challenge2()
	{
		// Arrange
		var inputData = GetInput();

		var sut = new Challenge2(101, 103);

		// Act
		var stepsCount = sut.Solve(inputData);
		var drawing = sut.DrawRobots(inputData);

		// Assert
		_testOutputHelper.WriteLine($"Result: {stepsCount}");
		_testOutputHelper.WriteLine(drawing);
	}
}
