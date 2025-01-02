using JetBrains.Annotations;

namespace Day13.Tests;

[TestSubject(typeof(Utils))]
public class UtilsTest
{
	[Fact]
	public void Parse_Should_Produce_Correct_Array()
	{
		// Arrange
		const string input =
			"Button A: X+94, Y+34\n" +
			"Button B: X+22, Y+67\n" +
			"Prize: X=8400, Y=5400\n" +
			"\n" +
			"Button A: X+26, Y+66\n" +
			"Button B: X+67, Y+21\n" +
			"Prize: X=12748, Y=12176\n" +
			"\n" +
			"Button A: X+17, Y+86\n" +
			"Button B: X+84, Y+37\n" +
			"Prize: X=7870, Y=6450\n" +
			"\n" +
			"Button A: X+69, Y+23\n" +
			"Button B: X+27, Y+71\n" +
			"Prize: X=18641, Y=10279\n";

		PuzzleMachine[] expected = [
			new (
				new Coord(94, 34),
				new Coord(22, 67),
				new Coord(8400, 5400)
			),
			new (
				new Coord(26, 66),
				new Coord(67, 21),
				new Coord(12748, 12176)
			),
			new (
				new Coord(17, 86),
				new Coord(84, 37),
				new Coord(7870, 6450)
			),
			new (
				new Coord(69, 23),
				new Coord(27, 71),
				new Coord(18641, 10279)
			),
		];

		// Act
		var actual = Utils.ParseInput(input);

		// Assert
		Assert.Equal(expected, actual);
	}
}
