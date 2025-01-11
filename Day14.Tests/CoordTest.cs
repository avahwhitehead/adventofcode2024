using JetBrains.Annotations;

namespace Day14.Tests;

[TestSubject(typeof(Coord))]
public class CoordTest
{
	[Theory]
	[InlineData(0, 0, 0, 0, true)]
	[InlineData(0, 1, 0, 1, true)]
	[InlineData(0, 6, 0, 1, false)]
	[InlineData(0, 1, 0, 6, false)]
	[InlineData(1, 0, 1, 0, true)]
	[InlineData(6, 0, 1, 0, false)]
	[InlineData(1, 0, 6, 0, false)]
	public void Equals_Should_Produce_Correct_Result(int x1, int y1, int x2, int y2, bool expected)
	{
		// Arrange
		var coord1 = new Coord(x1, y1);
		var coord2 = new Coord(x2, y2);

		// Act
		var actual = coord1.Equals(coord2);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(0, 0)]
	[InlineData(0, 1)]
	[InlineData(6, 6)]
	[InlineData(35748, 2448)]
	public void Clone_Should_Produce_Correct_Result(int x, int y)
	{
		// Arrange
		var original = new Coord(x, y);

		// Act
		var clone = original.Clone();

		// Assert
		Assert.NotSame(original, clone);
		Assert.Equal(original.X, clone.X);
		Assert.Equal(original.Y, clone.Y);
		Assert.Equal(original, clone);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	[InlineData(9, 5, 7, 3, 16, 8)]
	[InlineData(-9, 5, 7, -3, -2, 2)]
	public void Add_Should_Produce_Correct_Result(int x1, int y1, int x2, int y2, int expectedX, int expectedY)
	{
		// Arrange
		var coord1 = new Coord(x1, y1);
		var coord2 = new Coord(x2, y2);

		var expected = new Coord(expectedX, expectedY);

		// Act
		var actual = coord1.Add(coord2);

		// Assert
		Assert.Multiple(
			() => Assert.NotSame(coord1, actual),
			() => Assert.NotSame(coord2, actual),
			() => Assert.Equal(expected, actual)
		);
	}
}
