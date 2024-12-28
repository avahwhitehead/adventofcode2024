using JetBrains.Annotations;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Day9.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	private readonly ITestOutputHelper _testOutputHelper;

	public Challenge2Test(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void Example_Input_1_Should_Produce_Expected_Value()
	{
		// Arrange
		var input = "2333133121414131402";

		var inputArray = input
			.Select(c => c.ToString())
			.Select(byte.Parse)
			.ToArray();
		var sut = new Challenge2(inputArray);

		const int expected = 2858;

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
		var sut = new Challenge2(inputArray);

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
		var sut = new Challenge2(inputArray);

		ushort?[][] expectedArrays =
		[
			[ 0, 0, null, null, null, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, 8, 9, 9 ],
			[ 0, 0, 9, 9, null, 1, 1, 1, null, null, null, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, 7, 7, 7, null, 8, 8, 8, 8, null, null ],
			[ 0, 0, 9, 9, null, 1, 1, 1, 7, 7, 7, 2, null, null, null, 3, 3, 3, null, 4, 4, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, null, null, null, null, 8, 8, 8, 8, null, null ],
			[ 0, 0, 9, 9, null, 1, 1, 1, 7, 7, 7, 2, 4, 4, null, 3, 3, 3, null, null, null, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, null, null, null, null, 8, 8, 8, 8, null, null ],
			[ 0, 0, 9, 9, 2, 1, 1, 1, 7, 7, 7, null, 4, 4, null, 3, 3, 3, null, null, null, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, null, null, null, null, 8, 8, 8, 8, null, null ],
		];

		var endIndex = expectedArrays[0].Length;

		// Assert
		_testOutputHelper.WriteLine(JsonConvert.SerializeObject(sut.DiskArray));
		Assert.Equal(expectedArrays[0], sut.DiskArray);

		endIndex = sut.StepDefragmentation(endIndex);
		_testOutputHelper.WriteLine(JsonConvert.SerializeObject(sut.DiskArray));
		Assert.Equal(expectedArrays[1], sut.DiskArray);

		endIndex=  sut.StepDefragmentation(endIndex);
		_testOutputHelper.WriteLine(JsonConvert.SerializeObject(sut.DiskArray));
		Assert.Equal(expectedArrays[2], sut.DiskArray);

		endIndex = sut.StepDefragmentation(endIndex);
		_testOutputHelper.WriteLine(JsonConvert.SerializeObject(sut.DiskArray));
		Assert.Equal(expectedArrays[3], sut.DiskArray);

		endIndex = sut.StepDefragmentation(endIndex);
		_testOutputHelper.WriteLine(JsonConvert.SerializeObject(sut.DiskArray));
		Assert.Equal(expectedArrays[4], sut.DiskArray);
	}
}
