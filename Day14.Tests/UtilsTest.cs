using JetBrains.Annotations;

namespace Day14.Tests;

[TestSubject(typeof(Utils))]
public class UtilsTest
{
	[Fact]
	public void Parse_Should_Produce_Correct_Array()
	{
		// Arrange
		const string input =
			"p=0,4 v=3,-3\n" +
			"p=6,3 v=-1,-3\n" +
			"p=10,3 v=-1,2\n" +
			"p=2,0 v=2,-1\n" +
			"p=0,0 v=1,3\n" +
			"p=3,0 v=-2,-2\n" +
			"p=7,6 v=-1,-3\n" +
			"p=3,0 v=-1,-2\n" +
			"p=9,3 v=2,3\n" +
			"p=7,3 v=-1,2\n" +
			"p=2,4 v=2,-3\n" +
			"p=9,5 v=-3,-3\n";

		Robot[] expected =
		[
			new(
				new Coord(0, 4),
				new Coord(3, -3)
			),
			new(
				new Coord(6, 3),
				new Coord(-1, -3)
			),
			new(
				new Coord(10, 3),
				new Coord(-1, 2)
			),
			new(
				new Coord(2, 0),
				new Coord(2, -1)
			),
			new(
				new Coord(0, 0),
				new Coord(1, 3)
			),
			new(
				new Coord(3, 0),
				new Coord(-2, -2)
			),
			new(
				new Coord(7, 6),
				new Coord(-1, -3)
			),
			new(
				new Coord(3, 0),
				new Coord(-1, -2)
			),
			new(
				new Coord(9, 3),
				new Coord(2, 3)
			),
			new(
				new Coord(7, 3),
				new Coord(-1, 2)
			),
			new(
				new Coord(2, 4),
				new Coord(2, -3)
			),
			new(
				new Coord(9, 5),
				new Coord(-3, -3)
			),
		];

		// Act
		var actual = Utils.ParseInput(input);

		// Assert
		Assert.Equal(expected, actual);
	}
}
