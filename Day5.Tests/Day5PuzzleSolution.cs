using Xunit.Abstractions;

namespace Day5.Tests;

public class Day5PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day5.txt";

	private ((int DependencyPage, int DependentPage)[] Requirements, int[][] PageLists) GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		return Day5.Challenge1.Parse(fileContent);
	}

	[Fact]
	public void Challenge1()
	{
		// Arrange
		var (requirements, pageLists) = GetInput();

		var sut = new Challenge1(requirements);

		// Act
		var actualResult = sut.Solve(pageLists);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
