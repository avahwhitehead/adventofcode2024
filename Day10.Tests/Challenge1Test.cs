using JetBrains.Annotations;

namespace Day10.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input =
			"89010123\n" +
			"78121874\n" +
			"87430965\n" +
			"96549874\n" +
			"45678903\n" +
			"32019012\n" +
			"01329801\n" +
			"10456732\n";

		var grid = Utils.ParseInput(input);
		var sut = new Challenge1(grid);

		const int expected = 36;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}
}
