using JetBrains.Annotations;

namespace Day4.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge2();

		const string input =
			".M.S......\n" +
			"..A..MSMS.\n" +
			".M.S.MAA..\n" +
			"..A.ASMSM.\n" +
			".M.S.M....\n" +
			"..........\n" +
			"S.S.S.S.S.\n" +
			".A.A.A.A..\n" +
			"M.M.M.M.M.\n" +
			"..........";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		const int expected = 9;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Provided_Example_Input2_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge2();

		const string input =
			"M.S\n" +
			".A.\n" +
			"M.S\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		const int expected = 1;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Provided_Example_Input3_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge2();

		const string input =
			"S.M\n" +
			".A.\n" +
			"S.M\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		const int expected = 1;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Provided_Example_Input4_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge2();

		const string input =
			"S.S\n" +
			".A.\n" +
			"M.M\n";

		var inputArray = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		const int expected = 1;

		// Act
		var actual = sut.Solve(inputArray);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, "AGMSY")]
	[InlineData(0, 2, "CIO")]
	[InlineData(2, 0, "KQW")]
	[InlineData(2, 2, "MSY")]
	public void GetRightDiagonal_Should_Produce_Correct_Output(int row, int column, string expected)
	{
		// Arrange
		var sut = new Challenge2();

		var grid = new string[]
		{
			"ABCDE",
			"FGHIJ",
			"KLMNO",
			"PQRST",
			"UVWXY",
		};

		// Act
		var actual = sut.GetRightDiagonal(grid, row, column);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(0, 4, "EIMQU")]
	[InlineData(2, 4, "OSW")]
	[InlineData(2, 0, "K")]
	[InlineData(0, 2, "CGK")]
	[InlineData(2, 2, "MQU")]
	public void GetLeftDiagonalLines_Should_Produce_Correct_Output(int row, int column, string expected)
	{
		// Arrange
		var sut = new Challenge2();

		var grid = new string[]
		{
			"ABCDE",
			"FGHIJ",
			"KLMNO",
			"PQRST",
			"UVWXY",
		};

		// Act
		var actual = sut.GetLeftDiagonal(grid, row, column);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Small_Grid_Diagonals_Should_Be_Correct()
	{
		// Arrange
		var sut = new Challenge2();

		var grid = new string[]
		{
			"M.S",
			".A.",
			"M.S",
		};

		// Act
		var actualRightDiagonal = sut.GetRightDiagonal(grid, 0, 0);
		var actualLeftDiagonal = sut.GetLeftDiagonal(grid, 0, 2);

		// Assert
		Assert.Equal("MAS", actualRightDiagonal);
		Assert.Equal("SAM", actualLeftDiagonal);
	}

	[Fact]
	public void GetSubgrid_0_0_Should_Produce_Correct_Output()
	{
		// Arrange
		var sut = new Challenge2();

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
			"ABC",
			"FGH",
			"KLM"
		};

		// Act
		var actual = sut.GetSubGrid(grid, 0, 0, 3);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void GetSubgrid_1_2_Should_Produce_Correct_Output()
	{
		// Arrange
		var sut = new Challenge2();

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
			"HIJ",
			"MNO",
			"RST"
		};

		// Act
		var actual = sut.GetSubGrid(grid, 1, 2, 3);

		// Assert
		Assert.Equal(expected, actual);
	}
}
