using JetBrains.Annotations;

namespace Day7.Tests;

[TestSubject(typeof(Utils))]
public class UtilsTest
{
	[Fact]
	public void ParseEquations_Provided_Input_Should_Produce_Expected_Value()
	{
		// Arrange
		const string input =
			"190: 10 19\n" +
			"3267: 81 40 27\n" +
			"83: 17 5\n" +
			"156: 15 6\n" +
			"7290: 6 8 6 15\n" +
			"161011: 16 10 13\n" +
			"192: 17 8 14\n" +
			"21037: 9 7 18 13\n" +
			"292: 11 6 16 20\n";

		var expected = new Equation[]
		{
			new Equation(190, [10, 19]),
			new Equation(3267, [81, 40, 27]),
			new Equation(83, [17, 5]),
			new Equation(156, [15, 6]),
			new Equation(7290, [6, 8, 6, 15]),
			new Equation(161011, [16, 10, 13]),
			new Equation(192, [17, 8, 14]),
			new Equation(21037, [9, 7, 18, 13]),
			new Equation(292, [11, 6, 16, 20]),
		};

		// Act
		var actual = Utils.ParseEquations(input).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}
}
