using JetBrains.Annotations;

namespace Day6.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Provided_Example_Input_Should_Produce_Correct_Output()
	{
		// Arrange
		const string input =
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......#...";

		var sut = new Challenge1();

		const int expected = 41;

		// Act
		var grid = Grid.Parse(input);

		var actual = sut.Solve(grid);

		// Assert
		Assert.Equal(expected, actual);
	}
}
