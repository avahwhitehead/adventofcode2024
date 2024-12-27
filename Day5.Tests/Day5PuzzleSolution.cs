using Xunit.Abstractions;

namespace Day5.Tests;

public class Day5PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day5.txt";

	private (Dictionary<int, SortedSet<int>> Requirements, int[][] PageLists) GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		// Parse to puzzle input
		var (requirements, pageLists) = Utils.Parse(fileContent);

		return (Day5.Challenge1.MakeDependencyGraph(requirements), pageLists);
	}

	[Fact]
	public void Challenge1()
	{
		// Arrange
		var (dependenciesGraph, pageLists) = GetInput();

		var sut = new Challenge1(dependenciesGraph);

		// Act
		var actualResult = sut.Solve(pageLists);

		// Assert
		_testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
