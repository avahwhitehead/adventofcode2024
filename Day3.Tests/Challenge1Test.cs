using System.Collections.Generic;
using JetBrains.Annotations;
using Xunit;

namespace Day3.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge1();

		const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

		const int expected = 161;

		// Act
		var actual = sut.Solve(input);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindMuls_Should_Find_Correct_Values()
	{
		// Arrange
		var sut = new Challenge1();

		const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

		var expected = new List<(int Left, int Right)>
		{
			(2, 4),
			(5, 5),
			(11, 8),
			(8, 5),
		};

		// Act
		var actual = sut.FindMuls(input);

		// Assert
		Assert.Equal(expected, actual);
	}
}
