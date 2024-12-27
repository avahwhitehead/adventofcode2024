using JetBrains.Annotations;
using Xunit.Sdk;
using SquareContent = Day6.Grid.SquareContent;

namespace Day6.Tests;

[TestSubject(typeof(Grid))]
public class GridTest
{
	[Fact]
	public void Grid_ToString_Should_Produce_Expected_Value()
	{
		// Arrange
		const string input =
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......#...";

		var grid = Grid.Parse(input);

		// Act
		var actual = grid.ToString();

		// Assert
		Assert.Equal(input, actual);
	}

	[Fact]
	public void Grid_ToString_2_Should_Produce_Expected_Value()
	{
		// Arrange
		const string input =
			"....#.....\n" +
			"........>#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#........\n" +
			"........#.\n" +
			"#.........\n" +
			"......#...";

		var grid = Grid.Parse(input);

		// Act
		var actual = grid.ToString();

		// Assert
		Assert.Equal(input, actual);
	}

	[Fact]
	public void Grid_ToString_3_Should_Produce_Expected_Value()
	{
		// Arrange
		const string input =
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#........\n" +
			"........#.\n" +
			"#.........\n" +
			"......#v..";

		var grid = Grid.Parse(input);

		// Act
		var actual = grid.ToString();

		// Assert
		Assert.Equal(input, actual);
	}

	[Fact]
	public void Provided_Example_Input_Should_Be_Parsed_Correctly()
	{
		// Arrange
		const string input =
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......#...";

		var expected = new SquareContent?[][]
		{
			[null, null, null, null, SquareContent.Obstacle, null, null, null, null, null],
			[null, null, null, null, null, null, null, null, null, SquareContent.Obstacle],
			[null, null, null, null, null, null, null, null, null, null],
			[null, null, SquareContent.Obstacle, null, null, null, null, null, null, null],
			[null, null, null, null, null, null, null, SquareContent.Obstacle, null, null],
			[null, null, null, null, null, null, null, null, null, null],
			[null, SquareContent.Obstacle, null, null, SquareContent.GuardNorth, null, null, null, null, null],
			[null, null, null, null, null, null, null, null, SquareContent.Obstacle, null],
			[SquareContent.Obstacle, null, null, null, null, null, null, null, null, null],
			[null, null, null, null, null, null, SquareContent.Obstacle, null, null, null],
		};

		// Act
		var actual = Grid.Parse(input).GridArray;

		// Assert
		Assert.Multiple(
			() => Assert.Equal(expected.Length, actual.Length),
			() => Assert.Equal(expected[0], actual[0]),
			() => Assert.Equal(expected[1], actual[1]),
			() => Assert.Equal(expected[2], actual[2]),
			() => Assert.Equal(expected[3], actual[3]),
			() => Assert.Equal(expected[4], actual[4]),
			() => Assert.Equal(expected[5], actual[5]),
			() => Assert.Equal(expected[6], actual[6]),
			() => Assert.Equal(expected[7], actual[7]),
			() => Assert.Equal(expected[8], actual[8]),
			() => Assert.Equal(expected[9], actual[9])
		);
	}

	[Theory]
	[InlineData("...\n.^.\n...", true, 1, 1)]
	[InlineData("...\n.<.\n...", true, 1, 1)]
	[InlineData("...\n.>.\n...", true, 1, 1)]
	[InlineData("...\n.v.\n...", true, 1, 1)]
	[InlineData("...\n...\n...", false, null, null)]
	[InlineData("######", false, null, null)]
	[InlineData("..", false, null, null)]
	[InlineData("", false, null, null)]
	[InlineData("^.....", true, 0, 0)]
	[InlineData(".<", true, 1, 0)]
	[InlineData("<", true, 0, 0)]
	public void ContainsGuard(string input, bool expectedContainsGuard, int? guardX, int? guardY)
	{
		// Arrange
		var grid = Grid.Parse(input);

		// Act
		var actualContainsGuard = grid.ContainsGuard();
		var actualGuardPosition = grid.GuardPosition;

		// Assert
		Assert.Multiple(
			() => Assert.Equal(expectedContainsGuard, actualContainsGuard),
			() => Assert.Equal(expectedContainsGuard, actualGuardPosition != null),
			() => Assert.Equal(expectedContainsGuard, guardX != null),
			() => Assert.Equal(expectedContainsGuard, guardY != null),
			() =>
			{
				if (guardX == null) Assert.Null(actualGuardPosition);
				else Assert.Multiple(
					() => Assert.Equal(guardX, actualGuardPosition.Value.X),
					() => Assert.Equal(guardY, actualGuardPosition.Value.Y)
				);
			});
	}

	[Theory]
	[InlineData(0, 0, SquareContent.Obstacle)]
	[InlineData(4, 3, SquareContent.GuardNorth)]
	[InlineData(1, 2, SquareContent.GuardSouth)]
	[InlineData(3, 0, SquareContent.GuardEast)]
	[InlineData(3, 1, SquareContent.GuardWest)]
	[InlineData(3, 1, null)]
	public void SetSquare_should_Assign_To_Correct_Position(int x, int y, SquareContent? content)
	{
		// Arrange
		var grid = Grid.Parse(
			"...#..\n" +
			"...#..\n" +
			"......\n" +
			"......\n" +
			"......"
		);

		// Act
		grid.SetSquare(x, y, content);

		// Assert
		Assert.Equal(content, grid.GetSquare(x, y));
	}
}


[TestSubject(typeof(Grid))]
public class GridStepTest
{
	[Fact]
	public void Step_North_Free_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			".^.#\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".^..\n" +
			"...#\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_North_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			".^.#\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"..>#\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_North_East_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			".^#.\n" +
			"...."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"..#.\n" +
			".v.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_North_Leaving_Map_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#^..\n" +
			"....\n" +
			"...#\n" +
			".#.."
		);

		var expected = Grid.Parse(
			"#...\n" +
			"....\n" +
			"...#\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expected, grid);
	}

	[Fact]
	public void Step_South_Free_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			".v.#\n" +
			"...."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"...#\n" +
			".v.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_South_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			".v.#\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"<..#\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_South_West_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"#v.#\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".^..\n" +
			"#..#\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_South_Leaving_Map_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"...#\n" +
			".v.."
		);

		var expected = Grid.Parse(
			"#...\n" +
			"....\n" +
			"...#\n" +
			"...."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expected, grid);
	}

	[Fact]
	public void Step_East_Free_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			".>.#\n" +
			"...."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"..>#\n" +
			"...."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_East_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			".>#.\n" +
			"...."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"..#.\n" +
			".v.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_East_South_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			".>#.\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"<.#.\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_East_Leaving_Map_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"...>\n" +
			"...."
		);

		var expected = Grid.Parse(
			"#...\n" +
			"....\n" +
			"....\n" +
			"...."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expected, grid);
	}

	[Fact]
	public void Step_West_Free_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			".<.#\n" +
			"...."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"<..#\n" +
			"...."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_West_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"#<..\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".^..\n" +
			"#...\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_West_North_Obstacle_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"#<..\n" +
			".#.."
		);

		var expectedGrid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"#.>.\n" +
			".#.."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expectedGrid, grid);
	}

	[Fact]
	public void Step_West_Leaving_Map_Should_Produce_Expected_Value()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"<...\n" +
			"...."
		);

		var expected = Grid.Parse(
			"#...\n" +
			"....\n" +
			"....\n" +
			"...."
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expected, grid);
	}

	[Fact]
	public void Step_No_Guard_Should_Be_Unchanged()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"#...\n" +
			"..##"
		);

		var expected = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"#...\n" +
			"..##"
		);

		// Act
		grid.Step();

		// Assert
		Assert.Equal(expected, grid);
	}

	[Fact]
	public void WillGuardLoop_Stuck_In_Start()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			".#..\n" +
			"#^#.\n" +
			".#.#"
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Free_North()
	{
		// Arrange
		var grid = Grid.Parse(
			"#...\n" +
			"....\n" +
			"#^#.\n" +
			".#.#"
		);

		const bool expected = false;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Line()
	{
		// Arrange
		var grid = Grid.Parse(
			".#..\n" +
			"...#\n" +
			"#^..\n" +
			"..#."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Rectangle()
	{
		// Arrange
		var grid = Grid.Parse(
			".#....\n" +
			"....#.\n" +
			".^....\n" +
			"#.....\n" +
			"...#..\n" +
			"......"
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Border()
	{
		// Arrange
		var grid = Grid.Parse(
			".####.\n" +
			"#....#\n" +
			"#.>..#\n" +
			"#....#\n" +
			"#....#\n" +
			".####."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Bounce()
	{
		// Arrange
		var grid = Grid.Parse(
			"..##..\n" +
			".#..#.\n" +
			"......\n" +
			"......\n" +
			".#v.#.\n" +
			"..##.."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Complex()
	{
		// Arrange
		var grid = Grid.Parse(
			"...#...\n" +
			".#....#\n" +
			"....#..\n" +
			"..#.#..\n" +
			"...#...\n" +
			"#......\n" +
			".^...#."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_No_Guard()
	{
		// Arrange
		var grid = Grid.Parse(
			".......\n" +
			".......\n" +
			".......\n" +
			".......\n" +
			".......\n" +
			".......\n" +
			"......."
		);

		const bool expected = false;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Should_Not_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......#..."
		);

		const bool expected = false;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Change_1_Should_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#.#^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......#..."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Change_2_Should_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"......#.#.\n" +
			"#.........\n" +
			"......#..."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Change_3_Should_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			".......##.\n" +
			"#.........\n" +
			"......#..."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Change_4_Should_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"##........\n" +
			"......#..."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Change_5_Should_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#..#......\n" +
			"......#..."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void WillGuardLoop_Provided_Example_Change_6_Should_Loop()
	{
		// Arrange
		var grid = Grid.Parse(
			"....#.....\n" +
			".........#\n" +
			"..........\n" +
			"..#.......\n" +
			".......#..\n" +
			"..........\n" +
			".#..^.....\n" +
			"........#.\n" +
			"#.........\n" +
			"......##.."
		);

		const bool expected = true;

		// Act
		var actual = grid.WillGuardLoop();

		// Assert
		Assert.Equal(expected, actual);
	}
}
