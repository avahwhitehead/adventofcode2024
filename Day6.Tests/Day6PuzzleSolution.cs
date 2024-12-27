using Xunit.Abstractions;

namespace Day6.Tests;

public class Day6PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day6.txt";

	private string GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return fileContent;
	}

	[Fact]
	public void Challenge1()
	{
		// Arrange
		var sut = new Challenge1();

		var inputData = GetInput();

		var grid = Grid.Parse(inputData);

		// Act
		var actualResult = sut.Solve(grid);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
