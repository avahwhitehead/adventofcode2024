using JetBrains.Annotations;

namespace Day12.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge2Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var inputArray = Utils.ParseInput(
			"EEEEE\n" +
			"EXXXX\n" +
			"EEEEE\n" +
			"EXXXX\n" +
			"EEEEE"
		);
		var sut = new Challenge2(inputArray);

		const int expected = 236;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Example_Input_2_Should_Produce_Expected_Value()
	{
		// Arrange
		var inputArray = Utils.ParseInput(
			"AAAAAA\n" +
			"AAABBA\n" +
			"AAABBA\n" +
			"ABBAAA\n" +
			"ABBAAA\n" +
			"AAAAAA"
		);
		var sut = new Challenge2(inputArray);

		const int expected = 368;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetRegions_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var sut = new Challenge2([
			"EEEEE",
			"EXXXX",
			"EEEEE",
			"EXXXX",
			"EEEEE"
		]);

		const int expectedLength = 3;

		// Act
		var regions = sut.GetRegions().ToArray();

		// Assert
		Assert.Equal(expectedLength, regions.Length);

		Assert.Multiple(
			() => Assert.Equal(regions[0].GetCoords(), [
				new Coord(0, 0), new Coord(0, 1), new Coord(0, 2), new Coord(0, 3), new Coord(0, 4),
				new Coord(1, 0),
				new Coord(2, 0), new Coord(2, 1), new Coord(2, 2), new Coord(2, 3), new Coord(2, 4),
				new Coord(3, 0),
				new Coord(4, 0), new Coord(4, 1), new Coord(4, 2), new Coord(4, 3), new Coord(4, 4),
			]),
			() => Assert.Equal(17, regions[0].GetArea()),
			() => Assert.Equal(12, regions[0].GetNumberOfSides())
		);

		Assert.Multiple(
			() => Assert.Equal(regions[1].GetCoords(), [ new Coord(1, 1), new Coord(1, 2), new Coord(1, 3), new Coord(1, 4), ]),
			() => Assert.Equal(4, regions[1].GetArea()),
			() => Assert.Equal(4, regions[1].GetNumberOfSides())
		);

		Assert.Multiple(
			() => Assert.Equal(regions[2].GetCoords(), [ new Coord(3, 1), new Coord(3, 2), new Coord(3, 3), new Coord(3, 4) ]),
			() => Assert.Equal(4, regions[2].GetArea()),
			() => Assert.Equal(4, regions[2].GetNumberOfSides())
		);
	}
}
