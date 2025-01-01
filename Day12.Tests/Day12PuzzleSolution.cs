using Xunit.Abstractions;

namespace Day12.Tests;

public class Day12PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day12.txt";

	private string[] GetInput()
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
		var actualResult = sut.Solve();

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
