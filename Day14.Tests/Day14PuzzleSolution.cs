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
}
