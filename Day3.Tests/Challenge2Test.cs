using System.Collections.Generic;
using JetBrains.Annotations;
using Xunit;

namespace Day3.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge2();

		const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

		const int expected = 48;

		// Act
		var actual = sut.Solve(input);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindMuls_Should_Find_Correct_Values()
	{
		// Arrange
		var sut = new Challenge2();

		const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

		var expected = new List<(int Index, int Left, int Right)>
		{
			(1, 2, 4),
			(28, 5, 5),
			(48, 11, 8),
			(64, 8, 5),
		};

		// Act
		var actual = sut.FindMuls(input);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindDosAndDonts_Should_Find_Correct_Values()
	{
		// Arrange
		var sut = new Challenge2();

		const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

		var expected = new List<(int Index, bool IsDo)>
		{
			(20, false),
			(59, true),
		};

		// Act
		var actual = sut.FindDosAndDonts(input);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void FindRanges_Should_Produce_Correct_Values()
	{
		// Arrange
		var sut = new Challenge2();

		var input = new List<(int Index, bool IsDo)>
		{
			(0, true),
			(20, false),
			(59, true),
		};

		var expected = new List<(int StartIndex, int EndIndex, bool IsDo)>
		{
			(0, 19, true),
			(20, 58, false),
			(59, int.MaxValue, true),
		};

		// Act
		var actual = sut.GetRanges(input);

		// Assert
		Assert.Equal(expected, actual);
	}
}
