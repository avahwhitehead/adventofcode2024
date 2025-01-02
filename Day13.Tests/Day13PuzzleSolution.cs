using Xunit.Abstractions;

namespace Day13.Tests;

public class Day13PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day13.txt";

	private PuzzleMachine[] GetInput()
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

		var sut = new Challenge1();

		// Act
		var actualResult = sut.Solve(inputData);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
