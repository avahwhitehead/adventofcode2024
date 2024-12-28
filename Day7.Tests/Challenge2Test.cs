using JetBrains.Annotations;

namespace Day7.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Fact]
	public void Provided_Input_Should_Produce_Expected_Value()
	{
		// Arrange
		var sut = new Challenge2();

		var input = new Equation[]
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

		const int expected = 11387;

		// Act
		var actual = sut.Solve(input);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(190, 10, 19)]
	[InlineData(3267, 81, 40, 27)]
	[InlineData(292, 11, 6, 16, 20)]
	[InlineData(156, 15, 6)]
	[InlineData(7290, 6, 8, 6, 15)]
	[InlineData(192, 17, 8, 14)]
	public void Provided_Valid_Example_Inputs_Should_Return_True(int expected, params int[] values)
	{
		// Arrange
		var sut = new Challenge2();

		var equation = new Equation(expected, values);

		// Act
		var actual = sut.CanBeEvaluated(equation);

		// Assert
		Assert.True(actual);
	}

	[Theory]
	[InlineData(83, 17, 5)]
	[InlineData(161011, 16, 10, 13)]
	[InlineData(21037, 9, 7, 18, 13)]
	public void Provided_Invalid_Example_Inputs_Should_Return_False(int expected, params int[] values)
	{
		// Arrange
		var sut = new Challenge2();

		var equation = new Equation(expected, values);

		// Act
		var actual = sut.CanBeEvaluated(equation);

		// Assert
		Assert.False(actual);
	}
}
