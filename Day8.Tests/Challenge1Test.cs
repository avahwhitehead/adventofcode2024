using Day8;
using JetBrains.Annotations;

namespace Day8.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input =
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"....a.....\n" +
			"..........\n" +
			".....a....\n" +
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var sut = new Challenge1(inputArray);

		const int expected = 2;

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
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"....a.....\n" +
			"........a.\n" +
			".....a....\n" +
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"..........\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var sut = new Challenge1(inputArray);

		const int expected = 4;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Example_Input_3_Should_Produce_Expected_Value()
	{
		// Arrange
		var input =
			"..........\n" +
			"..........\n" +
			"..........\n" +
			"....a.....\n" +
			"........a.\n" +
			".....a....\n" +
			"..........\n" +
			"......A...\n" +
			"..........\n" +
			"..........\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var sut = new Challenge1(inputArray);

		const int expected = 4;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Example_Input_4_Should_Produce_Expected_Value()
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
		var sut = new Challenge1(inputArray);

		const int expected = 14;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(".......\n.......", "")]
	[InlineData("..A.90.\n..B.A0.", "AB90")]
	public void FindAntennaLabels_Should_Produce_Expected_Values(string grid, string expectedChars)
	{
		// Arrange
		var sut = new Challenge1(grid.Split('\n', StringSplitOptions.RemoveEmptyEntries));

		var expected = expectedChars.ToCharArray().ToList();
		expected.Sort();

		// Act
		var actual = sut.GetAntennaLabels().ToList();
		actual.Sort();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindAntennaPositions_0_Should_Produce_Expected_Values()
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
		var sut = new Challenge1(inputArray);

		const char antennaToFind = '0';

		Coord[] expected = [
			new (8, 1),
			new (5, 2),
			new (7, 3),
			new (4, 4),
		];

		// Act
		var actual = sut.FindAntennaPositions(antennaToFind).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindAntennaPositions_A_Should_Produce_Expected_Values()
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
		var sut = new Challenge1(inputArray);

		const char antennaToFind = 'A';

		Coord[] expected = [
			new (6, 5),
			new (8, 8),
			new (9, 9),
		];

		// Act
		var actual = sut.FindAntennaPositions(antennaToFind).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindAntennaPositions_C_Should_Find_Nothing()
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
		var sut = new Challenge1(inputArray);

		const char antennaToFind = 'C';

		Coord[] expected = [];

		// Act
		var actual = sut.FindAntennaPositions(antennaToFind).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 2, 2, 0, 0, 3, 3)]
	[InlineData(0, 0, 5, 5, -5, -5, 10, 10)]
	[InlineData(3, 5, 5, 3, 1, 7, 7, 1)]
	public void GetAntiNodes_Should_Produce_Correct_Results(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
	{
		// Arrange
		var sut = new Challenge1(null!);

		var coord1 = new Coord(x1, y1);
		var coord2 = new Coord(x2, y2);

		var expected1 = new Coord(expectedX1, expectedY1);
		var expected2 = new Coord(expectedX2, expectedY2);

		// Act
		var (actual1, actual2) = sut.GetAntiNodes(coord1, coord2);

		// Assert
		Assert.Equal(expected1, actual1);
		Assert.Equal(expected2, actual2);
	}
}
