using Xunit.Abstractions;

namespace Day9.Tests;

public class Day9PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

	private const string PuzzleFile = "inputs/day9.txt";

	private byte[] GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile).Trim('\n', '\r', ' ');

		// Parse to puzzle input
		return fileContent
			.Select(c => c.ToString())
			.Select(byte.Parse)
			.ToArray();
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
}
