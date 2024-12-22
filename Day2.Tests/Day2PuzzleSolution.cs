using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Day2.Tests;

public class Day2PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day2.txt";

	private int[][] GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return Utils.SplitInput(fileContent);
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
}
