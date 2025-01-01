using JetBrains.Annotations;

namespace Day12.Tests;

[TestSubject(typeof(Region))]
public class RegionTests
{
	[Theory]
	[InlineData(0, "")]
	[InlineData(0, "0")]
	[InlineData(4, "1")]
	[InlineData(4, "000\n010\n000")]
	[InlineData(6, "000\n010\n010")]
	[InlineData(8, "010\n010\n010")]
	[InlineData(10, "110\n010\n010")]
	[InlineData(14, "1100\n0100\n0111")]
	public void GetPerimeterLength_Should_Produce_Correct_Values(int expected, string regionMap)
	{
		// Arrange
		var region = new Region(ParseRegionMap(regionMap));

		// Act
		var actual = region.GetPerimeterLength();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(0, "")]
	[InlineData(0, "0")]
	[InlineData(1, "1")]
	[InlineData(1, "000\n010\n000")]
	[InlineData(2, "000\n010\n010")]
	[InlineData(3, "010\n010\n010")]
	[InlineData(4, "110\n010\n010")]
	[InlineData(6, "1100\n0100\n0111")]
	public void GetArea_Should_Produce_Correct_Values(int expected, string regionMap)
	{
		// Arrange
		var region = new Region(ParseRegionMap(regionMap));

		// Act
		var actual = region.GetArea();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(true, "")]
	[InlineData(true, "0")]
	[InlineData(true, "1")]
	[InlineData(true, "0110")]
	[InlineData(false, "01101")]
	[InlineData(true, "0011\n0010\n0110")]
	[InlineData(false, "0011\n0010\n0100")]
	public void IsRegionContiguous_Should_Produce_Correct_Values(bool expected, string regionMap)
	{
		// Arrange
		var region = ParseRegionMap(regionMap);

		// Act
		var actual = Region.IsRegionContiguous(region);

		// Assert
		Assert.Equal(expected, actual);
	}

	private bool[][] ParseRegionMap(string regionMap)
	{
		return regionMap
			.Split('\n', StringSplitOptions.RemoveEmptyEntries)
			.Select(
				row => row
					.ToCharArray()
					.Select(c => c == '1')
					.ToArray()
			)
			.ToArray();
	}
}
