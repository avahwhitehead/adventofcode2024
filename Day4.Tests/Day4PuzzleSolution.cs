using Xunit.Abstractions;

namespace Day4.Tests;

public class Day4PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day4.txt";

	private string[] GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return fileContent.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
	}

	[Fact]
	public void Challenge1()
	{
		// Arrange
		var sut = new Challenge1();

		var inputData = GetInput();

		// Act
		var actualResult = sut.Solve(inputData);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}

	[Fact]
	public void Challenge2()
	{
		// Arrange
		var sut = new Challenge2();

		var inputData = GetInput();

		// Act
		var actualResult = sut.Solve(inputData);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
