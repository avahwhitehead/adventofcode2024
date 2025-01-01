using JetBrains.Annotations;

namespace Day12.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input = "OOOOO\nOXOXO\nOOOOO\nOXOXO\nOOOOO\n";

		var inputArray = Utils.ParseInput(input);
		var sut = new Challenge1(inputArray);

		const int expected = 772;

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
			"RRRRIICCFF\n" +
			"RRRRIICCCF\n" +
			"VVRRRCCFFF\n" +
			"VVRCCCJFFF\n" +
			"VVVVCJJCFE\n" +
			"VVIVCCJJEE\n" +
			"VVIIICJJEE\n" +
			"MIIIIIJJEE\n" +
			"MIIISIJEEE\n" +
			"MMMISSJEEE";

		var inputArray = Utils.ParseInput(input);
		var sut = new Challenge1(inputArray);

		const int expected = 1930;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetRegions_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var sut = new Challenge1([
			"OOOOO",
			"OXOXO",
			"OOOOO",
			"OXOXO",
			"OOOOO"
		]);

		const int expectedLength = 5;

		// Act
		var regions = sut.GetRegions().ToArray();

		// Assert
		Assert.Equal(expectedLength, regions.Length);

		Assert.Multiple(
			() => Assert.Equal(regions[0].GetCoords(), [
				new Coord(0, 0), new Coord(0, 1), new Coord(0, 2), new Coord(0, 3), new Coord(0, 4),
				new Coord(1, 0), new Coord(1, 2), new Coord(1, 4),
				new Coord(2, 0), new Coord(2, 1), new Coord(2, 2), new Coord(2, 3), new Coord(2, 4),
				new Coord(3, 0), new Coord(3, 2), new Coord(3, 4),
				new Coord(4, 0), new Coord(4, 1), new Coord(4, 2), new Coord(4, 3), new Coord(4, 4),
			]),
			() => Assert.Equal(21, regions[0].GetArea()),
			() => Assert.Equal(36, regions[0].GetPerimeterLength())
		);

		Assert.Multiple(
			() => Assert.Equal(regions[1].GetCoords(), [ new Coord(1, 1) ]),
			() => Assert.Equal(1, regions[1].GetArea()),
			() => Assert.Equal(4, regions[1].GetPerimeterLength())
		);

		Assert.Multiple(
			() => Assert.Equal(regions[2].GetCoords(), [ new Coord(1, 3) ]),
			() => Assert.Equal(1, regions[2].GetArea()),
			() => Assert.Equal(4, regions[2].GetPerimeterLength())
		);

		Assert.Multiple(
			() => Assert.Equal(regions[3].GetCoords(), [ new Coord(3, 1) ]),
			() => Assert.Equal(1, regions[3].GetArea()),
			() => Assert.Equal(4, regions[3].GetPerimeterLength())
		);

		Assert.Multiple(
			() => Assert.Equal(regions[4].GetCoords(), [ new Coord(3, 3) ]),
			() => Assert.Equal(1, regions[4].GetArea()),
			() => Assert.Equal(4, regions[4].GetPerimeterLength())
		);
	}
}
