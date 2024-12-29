using JetBrains.Annotations;

namespace Day10.Tests;

[TestSubject(typeof(Utils))]
public class UtilsTest
{
	[Fact]
	public void Parse_Should_Produce_Correct_Array()
	{
		// Arrange
		var input =
			"89010123\n" +
			"78121874\n" +
			"87430965\n" +
			"96549874\n" +
			"45678903\n" +
			"32019012\n" +
			"01329801\n" +
			"10456732\n";

		int[][] expected =
		[
			[ 8, 9, 0, 1, 0, 1, 2, 3 ],
			[ 7, 8, 1, 2, 1, 8, 7, 4 ],
			[ 8, 7, 4, 3, 0, 9, 6, 5 ],
			[ 9, 6, 5, 4, 9, 8, 7, 4 ],
			[ 4, 5, 6, 7, 8, 9, 0, 3 ],
			[ 3, 2, 0, 1, 9, 0, 1, 2 ],
			[ 0, 1, 3, 2, 9, 8, 0, 1 ],
			[ 1, 0, 4, 5, 6, 7, 3, 2 ],
		];

		// Act
		var actual = Utils.ParseInput(input);

		// Assert
		Assert.Equal(expected, actual);
	}
}
