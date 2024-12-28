using Xunit.Abstractions;

namespace Day8.Tests;

public class Day8PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day8.txt";

	private string[] GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
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
		var actualResult = sut.Solve();

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
