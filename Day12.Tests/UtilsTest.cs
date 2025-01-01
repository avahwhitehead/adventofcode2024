using JetBrains.Annotations;

namespace Day12.Tests;

[TestSubject(typeof(Utils))]
public class UtilsTest
{
	[Fact]
	public void Parse_Should_Produce_Correct_Array()
	{
		// Arrange
		var input =
			"RRRRIICCFF\n" +
			"RRRRIICCCF\n" +
			"VVRRRCCFFF\n" +
			"VVRCCCJFFF\n" +
			"VVVVCJJCFE\n" +
			"VVIVCCJJEE\n" +
			"VVIIICJJEE\n" +
			"MIIIIIJJEE\n" +
			"MIIISIJEEE\n" +
			"MMMISSJEEE\n";

		string[] expected = [
			"RRRRIICCFF",
			"RRRRIICCCF",
			"VVRRRCCFFF",
			"VVRCCCJFFF",
			"VVVVCJJCFE",
			"VVIVCCJJEE",
			"VVIIICJJEE",
			"MIIIIIJJEE",
			"MIIISIJEEE",
			"MMMISSJEEE"
		];

		// Act
		var actual = Utils.ParseInput(input);

		// Assert
		Assert.Equal(expected, actual);
	}
}
