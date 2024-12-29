namespace Day10.Tests;

public class Challenge2Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input =
			"012345\n" +
			"123456\n" +
			"234567\n" +
			"345678\n" +
			"416789\n" +
			"567891\n";

		var grid = Utils.ParseInput(input);
		var sut = new Challenge2(grid);

		const int expected = 227;

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
			"89010123\n" +
			"78121874\n" +
			"87430965\n" +
			"96549874\n" +
			"45678903\n" +
			"32019012\n" +
			"01329801\n" +
			"10456732\n";

		var grid = Utils.ParseInput(input);
		var sut = new Challenge2(grid);

		const int expected = 81;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}
}
