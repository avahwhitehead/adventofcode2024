using JetBrains.Annotations;

namespace Day9.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input = "2333133121414131402";

		var inputArray = input
			.Select(c => c.ToString())
			.Select(byte.Parse)
			.ToArray();
		var sut = new Challenge1(inputArray);

		const int expected = 1928;

		// Act
		var actual = sut.Solve();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Example_Input_Parse_Should_Produce_Correct_DiskArray()
	{
		// Arrange
		var input = "2333133121414131402";

		var inputArray = input
			.Select(c => c.ToString())
			.Select(byte.Parse)
			.ToArray();

		ushort?[] expectedArray =
			[0, 0, null, null, null, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, 8, 9, 9];

		// Act
		var sut = new Challenge1(inputArray);

		var actual = sut.DiskArray;

		// Assert
		Assert.Equal(expectedArray, actual);
	}

	[Fact]
	public void Example_Input_1_Steps_Should_Occur_In_Order()
	{
		// Arrange
		var input = "2333133121414131402";

		var inputArray = input
			.Select(c => c.ToString())
			.Select(byte.Parse)
			.ToArray();
		var sut = new Challenge1(inputArray);

		ushort?[][] expectedArrays =
		[
			[0, 0, null, null, null, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, 8, 9, 9],
			[ 0, 0, 9, null, null, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, 8, 9, null ],
			[ 0, 0, 9, 9, null, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, 8, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, null, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, null, null, null, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, 7, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, null, null, null, null, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, 7, 7, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, null, null, null, null, null, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, 7, 7, 3, 3, 3, 6, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, null, null, null, null, null, null, null, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, 7, 7, 3, 3, 3, 6, 4, 4, 6, 5, 5, 5, 5, null, 6, 6, null, null, null, null, null, null, null, null, null, null, null, null, null ],
			[ 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, 7, 7, 3, 3, 3, 6, 4, 4, 6, 5, 5, 5, 5, 6, 6, null, null, null, null, null, null, null, null, null, null, null, null, null, null ],
		];

		// Assert
		Assert.Equal(expectedArrays[0], sut.DiskArray);

		foreach (var expected in expectedArrays.Skip(1))
		{
			// Act
			sut.StepDefragmentation();
			var actual = sut.DiskArray;

			// Assert
			Assert.Equal(expected, actual);
		}
	}

	[Theory]
	[InlineData("2333133121414131402", false)]
	[InlineData("2", true)]
	[InlineData("20", true)]
	[InlineData("203040", true)]
	[InlineData("00000", true)]
	[InlineData("003040", true)]
	[InlineData("102033", true)]
	[InlineData("1020334", false)]
	public void IsDiskComplete_Should_Produce_Correct_Result(string diskLayout, bool expected)
	{
		// Arrange
		var inputArray = diskLayout
			.Select(c => c.ToString())
			.Select(byte.Parse)
			.ToArray();
		var sut = new Challenge1(inputArray);

		// Act
		var actual = sut.IsDiskComplete();

		// Assert
		Assert.Equal(expected, actual);
	}
}
