using Xunit.Abstractions;

namespace Day7.Tests;

public class Day7PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day7.txt";

	private IEnumerable<Equation> GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return Utils.ParseEquations(fileContent);
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
