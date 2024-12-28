using JetBrains.Annotations;

namespace Day8.Tests;

[TestSubject(typeof(Challenge1))]
public class FractionTest
{
	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(8, 4, 4)]
	[InlineData(64, 32, 32)]
	[InlineData(21, 14, 7)]
	[InlineData(14, 35, 7)]
	[InlineData(7, 5, 1)]
	[InlineData(7, 7, 7)]
	public void GreatestCommonDivisor_Should_Return_Correct_Result(int numerator, int denominator, int expectedResult)
	{
		// Arrange
		var fraction = new Fraction(numerator, denominator);

		// Act
		var actualResult = fraction.GreatestCommonDivisor();

		// Assert
		Assert.Equal(expectedResult, actualResult);
	}

	[Theory]
	[InlineData(1, 1, 1, 1)]
	[InlineData(8, 4, 2, 1)]
	[InlineData(32, 64, 1, 2)]
	[InlineData(19, 8, 19, 8)]
	[InlineData(1000, 255, 200, 51)]
	[InlineData(255, 1000, 51, 200)]
	public void Simplify_Should_Return_Correct_Result(int numerator, int denominator, int expectedNumerator, int expectedDenominator)
	{
		// Arrange
		var fraction = new Fraction(numerator, denominator);

		var expectedFraction = new Fraction(expectedNumerator, expectedDenominator);

		// Act
		var actualResult = fraction.Simplify();

		// Assert
		Assert.Multiple(
			() => Assert.NotSame(fraction, actualResult),
			() => Assert.Equal(expectedFraction, actualResult)
		);
	}
}
