using JetBrains.Annotations;

namespace Day4.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge1();

		const string input =
			"MMMSXXMASM\n" +
			"MSAMXMSMSA\n" +
			"AMXSXMAAMM\n" +
			"MSAMASMSMX\n" +
			"XMASAMXAMM\n" +
			"XXAMMXXAMA\n" +
			"SMSMSASXSS\n" +
			"SAXAMASAAA\n" +
			"MAMMMXMMMM\n" +
			"MXMXAXMASX";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		const int expected = 18;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Provided_Example_Input2_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge1();

		const string input =
			"..X...\n" +
			".SAMX.\n" +
			".A..A.\n" +
			"XMAS.S\n" +
			".X....\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		const int expected = 4;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}


	[Theory]
	[InlineData("XMAS", 1)]
	[InlineData("XMASSAMX", 2)]
	[InlineData("XMASAMX", 2)]
	[InlineData("XMASXMASXMAS", 3)]
	[InlineData("XMASXMA", 1)]
	[InlineData("SMAXMA", 0)]
	[InlineData("SAMXMA", 1)]
	[InlineData("SMAXMAS", 1)]
	[InlineData("SAMXMAS", 2)]
	[InlineData("XXXXXXXXSAMXMASSSSAXMAMAX", 2)]
	public void FindXmasHorizontally_ShouldSucceed(string line, int expectedCount)
	{
		// Arrange
		var sut = new Challenge1();

		// Act
		var actual = sut.FindXmasHorizontally(line);

		// Assert
		Assert.Equal(expectedCount, actual);
	}

	[Fact]
	public void GetVerticalLines_Should_Produce_Correct_Output()
	{
		// Arrange
		var sut = new Challenge1();

		var grid = new string[]
		{
			"ABCDE",
			"FGHIJ",
			"KLMNO",
			"PQRST",
			"UVWXY",
		};

		var expected = new string[]
		{
			"AFKPU",
			"BGLQV",
			"CHMRW",
			"DINSX",
			"EJOTY"
		};

		// Act
		var actual = sut.GetVerticalLines(grid).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetRightDiagnonalLines_Should_Produce_Correct_Output()
	{
		// Arrange
		var sut = new Challenge1();

		var grid = new string[]
		{
			"ABCDE",
			"FGHIJ",
			"KLMNO",
			"PQRST",
			"UVWXY",
		};

		var expected = new string[]
		{
			"E", "DJ", "CIO", "BHNT", "AGMSY", "FLRX", "KQW", "PV", "U"
		};

		// Act
		var actual = sut.GetRightDiagonalLines(grid).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetLeftDiagnonalLines_Should_Produce_Correct_Output()
	{
		// Arrange
		var sut = new Challenge1();

		var grid = new string[]
		{
			"ABCDE",
			"FGHIJ",
			"KLMNO",
			"PQRST",
			"UVWXY",
		};

		var expected = new string[]
		{
			"A", "BF", "CGK", "DHLP", "EIMQU", "JNRV", "OSW", "TX", "Y"
		};

		// Act
		var actual = sut.GetLeftDiagonalLines(grid).ToArray();

		// Assert
		Assert.Equal(expected, actual);
	}
}
