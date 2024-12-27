using JetBrains.Annotations;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Day5.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2ExpectedInputTest
{
	// The dependent page depends on the dependency page
	private static readonly (int DependencyPage, int DependentPage)[] Dependencies =
	[
		(47, 53),
		(97, 13),
		(97, 61),
		(97, 47),
		(75, 29),
		(61, 13),
		(75, 53),
		(29, 13),
		(97, 29),
		(53, 29),
		(61, 53),
		(97, 53),
		(61, 29),
		(47, 13),
		(75, 47),
		(97, 75),
		(47, 61),
		(75, 61),
		(47, 29),
		(75, 13),
		(53, 13)
	];

	private static readonly Dictionary<int, SortedSet<int>> DependenciesGraph =
		Challenge1.MakeDependencyGraph(Dependencies);

	[Fact]
	public void Example_Input_Should_Return_Expected_Result()
	{
		// Arrange
		var sut = new Challenge2(DependenciesGraph);

		var pageLists = new int[][]
		{
			[75, 97, 47, 61, 53],
			[61, 13, 29],
			[97, 13, 75, 29, 47],
		};

		const int expectedValue = 123;

		// Act
		var actual = sut.Solve(pageLists);

		// Assert
		Assert.Equal(expectedValue, actual);
	}

	[Fact]
	public void First_Example_List_Should_Be_Ordered_Correctly()
	{
		// Arrange
		var challenge1 = new Challenge1(DependenciesGraph);
		var sut = new Challenge2(DependenciesGraph);

		var pages = new int[] { 75, 97, 47, 61, 53 };
		var expectedOrder = new int[] { 97, 75, 47, 61, 53 };

		// Act
		var actual = sut.Order(pages);

		// Assert
		Assert.Multiple(
			() => Assert.True(challenge1.IsOrdered(actual)),
			() => Assert.Equal(expectedOrder, actual)
		);
	}

	[Fact]
	public void Second_Example_ListShould_Bet_Ordered_Correctly()
	{
		// Arrange
		var challenge1 = new Challenge1(DependenciesGraph);
		var sut = new Challenge2(DependenciesGraph);

		var pages = new int[] { 61, 13, 29 };
		var expectedOrder = new int[] { 61, 29, 13 };

		// Act
		var actual = sut.Order(pages);

		// Assert
		Assert.Multiple(
			() => Assert.True(challenge1.IsOrdered(actual)),
			() => Assert.Equal(expectedOrder, actual)
		);
	}

	[Fact]
	public void Third_Example_List_Should_Be_Ordered_Correctly()
	{
		// Arrange
		var challenge1 = new Challenge1(DependenciesGraph);
		var sut = new Challenge2(DependenciesGraph);

		var pages = new int[] { 97, 13, 75, 29, 47 };
		var expectedOrder = new int[] { 97, 75, 47, 29, 13 };

		// Act
		var actual = sut.Order(pages);

		// Assert
		Assert.Multiple(
			() => Assert.True(challenge1.IsOrdered(actual)),
			() => Assert.Equal(expectedOrder, actual)
		);
	}
}

[TestSubject(typeof(Challenge2))]
public class Challenge2RealInputTest(ITestOutputHelper testOutputHelper)
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
	public void Order_Should_Be_Ordered_Correctly_For_All_Lists()
	{
		// Arrange
		var (dependenciesGraph, pageLists) = GetInput();

		var challenge1 = new Challenge1(dependenciesGraph);
		var sut = new Challenge2(dependenciesGraph);

		var unorderedPageLists = pageLists.Where(pages => !challenge1.IsOrdered(pages)).ToArray();

		foreach (var pageList in unorderedPageLists)
		{
			// Act
			var orderedList = sut.Order(pageList);

			// Assert
			var isOrdered = challenge1.IsOrdered(orderedList);
			if (!isOrdered)
			{
				_testOutputHelper.WriteLine(JsonConvert.SerializeObject(orderedList));
			}
			Assert.True(isOrdered);
		}
	}

	[Fact]
	public void First_List_Should_Be_Ordered_Correctly()
	{
		// Arrange
		var (dependenciesGraph, _) = GetInput();

		var challenge1 = new Challenge1(dependenciesGraph);
		var sut = new Challenge2(dependenciesGraph);

		// 98 depends on 15
		var pageList = new int[] { 98, 85, 15, 24, 46, 97, 19, 89, 87, 44, 57 };

		// Act
		var orderedList = sut.Order(pageList);

		// Assert
		Assert.True(challenge1.IsOrdered(orderedList));
	}
}
