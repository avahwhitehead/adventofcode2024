using JetBrains.Annotations;

namespace Day5.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1ExpectedInputTest
{
	// The dependent page depends on the dependency page
	(int DependencyPage, int DependentPage)[] Dependencies =
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

	[Fact]
	public void Example_Input_Should_Return_Expected_Result()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pageLists = new int[][]
		{
			[75, 47, 61, 53, 29],
			[97, 61, 53, 29, 13],
			[75, 29, 13],
			[75, 97, 47, 61, 53],
			[61, 13, 29],
			[97, 13, 75, 29, 47],
		};

		const int expectedValue = 143;

		// Act
		var actual = sut.Solve(pageLists);

		// Assert
		Assert.Equal(expectedValue, actual);
	}

	[Fact]
	public void Parse_Should_Return_Expected_Input()
	{
		// Arrange
		const string inputString =
			"47|53\n" +
			"97|13\n" +
			"97|61\n" +
			"97|47\n" +
			"75|29\n" +
			"61|13\n" +
			"75|53\n" +
			"29|13\n" +
			"97|29\n" +
			"53|29\n" +
			"61|53\n" +
			"97|53\n" +
			"61|29\n" +
			"47|13\n" +
			"75|47\n" +
			"97|75\n" +
			"47|61\n" +
			"75|61\n" +
			"47|29\n" +
			"75|13\n" +
			"53|13" +
			"\n\n" +
			"75,47,61,53,29\n" +
			"97,61,53,29,13\n" +
			"75,29,13\n" +
			"75,97,47,61,53\n" +
			"61,13,29\n" +
			"97,13,75,29,47\n";

		var expectedPageLists = new int[][]
		{
			[75, 47, 61, 53, 29],
			[97, 61, 53, 29, 13],
			[75, 29, 13],
			[75, 97, 47, 61, 53],
			[61, 13, 29],
			[97, 13, 75, 29, 47],
		};

		// Act
		var result = Challenge1.Parse(inputString);

		// Assert
		Assert.Equal(Dependencies, result.Requirements);
		Assert.Equal(expectedPageLists, result.PageLists);
	}

	[Fact]
	public void Make_Dependency_Graph_Should_Return_Expected_Graph()
	{
		// Arrange
		var expectedGraph = new Dictionary<int, SortedSet<int>>
		{
			[ 13 ] = [ 29, 47, 53, 61, 75, 97 ],
			[ 29 ] = [ 47, 53, 61, 75, 97 ],
			[ 47 ] = [ 75, 97 ],
			[ 53 ] = [ 47, 61, 75, 97 ],
			[ 61 ] = [ 47, 75, 97 ],
			[ 75 ] = [ 97 ],
		};

		// Act
		var actualGraph = Challenge1.MakeDependencyGraph(Dependencies);

		// Assert
		var checks = new List<Action>
		{
			() => Assert.Equal(expectedGraph.Count, actualGraph.Count),
		};

		foreach (var (page, dependencies) in expectedGraph)
		{
			checks.Add(
				() => Assert.Multiple(
					() => Assert.True(actualGraph.ContainsKey(page)),
					() => Assert.Equal(dependencies, actualGraph[page])
				)
			);
		}

		Assert.Multiple(checks.ToArray());
	}

	[Fact]
	public void First_Example_List_Is_Ordered_Correctly()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pages = new int[] { 75, 47, 61, 53, 29 };

		// Act
		var actual = sut.IsOrdered(pages);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void Second_Example_List_Is_Ordered_Correctly()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pages = new int[] { 97, 61, 53, 29, 13 };

		// Act
		var actual = sut.IsOrdered(pages);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void Third_Example_List_Is_Ordered_Correctly()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pages = new int[] { 75, 29, 13 };

		// Act
		var actual = sut.IsOrdered(pages);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void Fourth_Example_List_Is_ONot_rdered_Correctly()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pages = new int[] { 75, 97, 47, 61, 53 };

		// Act
		var actual = sut.IsOrdered(pages);

		// Assert
		Assert.False(actual);
	}

	[Fact]
	public void Fifth_Example_List_Is_Not_Ordered_Correctly()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pages = new int[] { 61, 13, 29 };

		// Act
		var actual = sut.IsOrdered(pages);

		// Assert
		Assert.False(actual);
	}

	[Fact]
	public void Sixth_Example_List_Is_Not_Ordered_Correctly()
	{
		// Arrange
		var sut = new Challenge1(Dependencies);

		var pages = new int[] { 97, 13, 75, 29, 47 };

		// Act
		var actual = sut.IsOrdered(pages);

		// Assert
		Assert.False(actual);
	}
}

/*
[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge1();

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}
}
*/
