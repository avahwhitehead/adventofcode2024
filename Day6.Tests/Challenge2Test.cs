using JetBrains.Annotations;

namespace Day6.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Fact]
	public void Provided_Example_Input_Should_Produce_Correct_Output()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......#..."
		);

		var sut = new Challenge2();

		const int expected = 6;

		// Act
		var actual = sut.Solve(grid);

		// Assert
		Assert.Equal(expected, actual);
	}
}
