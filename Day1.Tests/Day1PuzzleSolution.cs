using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Day1.Tests;

public class Day1PuzzleSolution(ITestOutputHelper testOutputHelper)
{
	private const string PuzzleFile = "inputs/day1.txt";

	private Tuple<int[], int[]> GetInput()
	{
		// Read the puzzle file
		var fileContent = File.ReadAllText(PuzzleFile);

		var splitContent = fileContent.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries);

		var listA = new int[splitContent.Length];
		var listB = new int[splitContent.Length];

		for (var i = 0; i < splitContent.Length; i++)
		{
			var line = splitContent[i];
			var splitLine = line.Split(["   "], StringSplitOptions.None);

			listA[i] = int.Parse(splitLine[0]);
			listB[i] = int.Parse(splitLine[1]);
		}

		return new Tuple<int[], int[]>(listA, listB);
	}

	[Fact]
	public void Challenge1()
	{
		// Arrange
		var sut = new Challenge1();

		var (listA, listB) = GetInput();

		// Act
		var actualResult = sut.ReconcileLists(listA, listB);

		// Assert
		testOutputHelper.WriteLine($"Result: {actualResult}");
	}

	[Fact]
	public void Challenge2()
	{
		// Arrange
		var sut = new Challenge2();

		var (listA, listB) = GetInput();

		// Act
		var actualResult = sut.Solve(listA, listB);

		// Assert
		testOutputHelper.WriteLine($"Result: {actualResult}");
	}
}
