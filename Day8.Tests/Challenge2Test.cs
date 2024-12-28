using JetBrains.Annotations;

namespace Day8.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input =
			"T.........\n" +
			"...T......\n" +
			".T........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var sut = new Challenge2(inputArray);

		const int expected = 9;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Example_Input_2_Should_Produce_Expected_Value()
	{
		// Arrange
		var input =
			"............\n" +
			"........0...\n" +
			".....0......\n" +
			".......0....\n" +
			"....0.......\n" +
			"......A.....\n" +
			"............\n" +
			"............\n" +
			"........A...\n" +
			".........A..\n" +
			"............\n" +
			"............\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var sut = new Challenge2(inputArray);

		const int expected = 34;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetAntiNodes_Should_Produce_Correct_Results_1()
	{
		// Arrange
		string[] grid = [
			"T.........",
			"...T......",
			".T........",
			"..........",
			"..........",
			"..........",
			"..........",
			"..........",
			"..........",
			"..........",
		];

		var sut = new Challenge2(grid);

		var coord1 = new Coord(0, 0);
		var coord2 = new Coord(3, 1);

		var expected = new Coord[]
		{
			new Coord(0, 0),
			new Coord(3, 1),
			new Coord(6, 2),
			new Coord(9, 3),
		};

		// Act
		var actual = sut.GetAntiNodes(coord1, coord2).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetAntiNodes_Should_Produce_Correct_Results_2()
	{
		// Arrange
		string[] grid = [
			"T.........",
			"...T......",
			".T........",
			"..........",
			"..........",
			"..........",
			"..........",
			"..........",
			"..........",
			"..........",
		];

		var sut = new Challenge2(grid);

		var coord1 = new Coord(0, 0);
		var coord2 = new Coord(1, 2);

		var expected = new Coord[]
		{
			new Coord(0, 0),
			new Coord(1, 2),
			new Coord(2, 4),
			new Coord(3, 6),
			new Coord(4, 8),
		};

		// Act
		var actual = sut.GetAntiNodes(coord1, coord2).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}
}
