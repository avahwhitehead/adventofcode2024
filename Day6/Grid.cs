using System.Text;

namespace Day6;

public class Grid
{
	private readonly SquareContent?[][] _grid;

	private (int X, int Y)? _guardPosition;

	public SquareContent?[][] GridArray => _grid;

	public (int X, int Y)? GuardPosition => _guardPosition;

	public Grid(SquareContent?[][] grid)
	{
		_grid = grid;
		_guardPosition = FindGuardPosition(grid);
	}

	public bool ContainsGuard()
	{
		return _guardPosition != null;
	}

	public void Step()
	{
		if (!ContainsGuard()) return;
		var guard = GetSquare(_guardPosition!.Value);

		switch (guard)
		{
			case SquareContent.GuardNorth:
				MoveGuardNorth();
				return;
			case SquareContent.GuardSouth:
				MoveGuardSouth();
				return;
			case SquareContent.GuardEast:
				MoveGuardEast();
				return;
			case SquareContent.GuardWest:
				MoveGuardWest();
				return;
		}
	}

	public bool WillGuardLoop(int maxSteps = 100)
	{
		var stepHistory = new HashSet<(int X, int Y, SquareContent GuardDirection)>();

		if (!ContainsGuard()) return false;

		var currentStep = 0;
		do
		{
			var guardPosition = _guardPosition!.Value;
			var guardDirection = GetSquare(guardPosition);

			// Record the current position in the history
			// If an identical position has been added before, we know it will loop
			var stepData = (guardPosition.X, guardPosition.Y, guardDirection!.Value);
			if (!stepHistory.Add(stepData)) return true;

			try
			{
				Step();
			}
			catch (InfiniteLoopException)
			{
				return true;
			}

			// Guard has left the map
			// No loop
			if (!ContainsGuard()) return false;
		} while (++currentStep < maxSteps);

		// Didn't loop within the maximum number of steps
		return false;
	}

	private void RotateGuardRight()
	{
		var xIndex = _guardPosition!.Value.X;
		var yIndex = _guardPosition!.Value.Y;

		var guard = _grid[yIndex][xIndex];
		_grid[yIndex][xIndex] = guard switch
		{
			SquareContent.GuardNorth => SquareContent.GuardEast,
			SquareContent.GuardEast => SquareContent.GuardSouth,
			SquareContent.GuardSouth => SquareContent.GuardWest,
			SquareContent.GuardWest => SquareContent.GuardNorth,
			_ => _grid[yIndex][xIndex]
		};
	}

	private void ClearSquare((int X, int Y) position)
	{
		_grid[position.Y][position.X] = null;
	}

	private void ClearSquare(int x, int y)
	{
		_grid[y][x] = null;
	}

	public void SetSquare(int x, int y, SquareContent? content)
	{
		_grid[y][x] = content;
	}

	public void SetSquare((int X, int Y) position, SquareContent? content)
	{
		_grid[position.Y][position.X] = content;
	}

	public SquareContent? GetSquare(int x, int y)
	{
		return _grid[y][x];
	}

	public SquareContent? GetSquare((int X, int Y) position)
	{
		return _grid[position.Y][position.X];
	}

	private void MoveGuardNorth(SquareContent? originalGuardPosition = null)
	{
		if (originalGuardPosition == SquareContent.GuardNorth) throw new InfiniteLoopException("Guard has done a full rotation.");

		// Check if the row is at the top of the grid
		// (Guard will step off-screen)
		if (_guardPosition!.Value.Y == 0)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = null;
			return;
		}

		var newGuardPosition = (_guardPosition!.Value.X, _guardPosition!.Value.Y - 1);

		// Check if the square above is free
		// (Guard can move freely)
		if (GetSquare(newGuardPosition) == null)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = newGuardPosition;
			SetSquare(_guardPosition.Value, SquareContent.GuardNorth);
			return;
		}

		// Square above is occupied
		// (Guard turns right)
		RotateGuardRight();
		MoveGuardEast(originalGuardPosition ?? SquareContent.GuardNorth);
	}

	private void MoveGuardSouth(SquareContent? originalGuardPosition = null)
	{
		if (originalGuardPosition == SquareContent.GuardSouth) throw new InfiniteLoopException("Guard has done a full rotation.");

		// Check if the row is at the bottom of the grid
		// (Guard will step off-screen)
		if (_guardPosition!.Value.Y == _grid.Length - 1)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = null;
			return;
		}

		var newGuardPosition = (_guardPosition!.Value.X, _guardPosition!.Value.Y + 1);

		// Check if the square above is free
		// (Guard can move freely)
		if (GetSquare(newGuardPosition) == null)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = newGuardPosition;
			SetSquare(_guardPosition.Value, SquareContent.GuardSouth);
			return;
		}

		// Square above is occupied
		// (Guard turns right)
		RotateGuardRight();
		MoveGuardWest(originalGuardPosition ?? SquareContent.GuardSouth);
	}

	private void MoveGuardEast(SquareContent? originalGuardPosition = null)
	{
		if (originalGuardPosition == SquareContent.GuardEast) throw new InfiniteLoopException("Guard has done a full rotation.");

		// Check if the row is at the right of the grid
		// (Guard will step off-screen)
		if (_guardPosition!.Value.X == _grid[_guardPosition!.Value.X].Length - 1)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = null;
			return;
		}

		var newGuardPosition = (_guardPosition!.Value.X + 1, _guardPosition!.Value.Y);

		// Check if the square above is free
		// (Guard can move freely)
		if (GetSquare(newGuardPosition) == null)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = newGuardPosition;
			SetSquare(_guardPosition.Value, SquareContent.GuardEast);
			return;
		}

		// Square above is occupied
		// (Guard turns right)
		RotateGuardRight();
		MoveGuardSouth(originalGuardPosition ?? SquareContent.GuardEast);
	}

	private void MoveGuardWest(SquareContent? originalGuardPosition = null)
	{
		if (originalGuardPosition == SquareContent.GuardWest) throw new InfiniteLoopException("Guard has done a full rotation.");

		// Check if the row is at the right of the grid
		// (Guard will step off-screen)
		if (_guardPosition!.Value.X == 0)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = null;
			return;
		}

		var newGuardPosition = (_guardPosition!.Value.X - 1, _guardPosition!.Value.Y);

		// Check if the square above is free
		// (Guard can move freely)
		if (GetSquare(newGuardPosition) == null)
		{
			ClearSquare(_guardPosition!.Value);

			_guardPosition = newGuardPosition;
			SetSquare(_guardPosition.Value, SquareContent.GuardWest);
			return;
		}

		// Square above is occupied
		// (Guard turns right)
		RotateGuardRight();
		MoveGuardNorth(originalGuardPosition ?? SquareContent.GuardWest);
	}

	public override string ToString()
	{
		var sb = new StringBuilder();

		foreach (var row in _grid)
		{
			sb.AppendLine(string.Join("", row.Select(CharacterToString).ToArray()));
		}

		return sb.ToString().TrimEnd();
	}

	public override bool Equals(object? obj)
	{
		if (obj is not Grid grid) return false;
		if (grid.GridArray.Length != _grid.Length) return false;

		return _grid.Zip(grid.GridArray, (a, b) => a.SequenceEqual(b)).All(b => b);
	}

	public Grid Clone()
	{
		return new Grid(
			GridArray.Select(row => row.ToArray()).ToArray()
		);
	}

	public static Grid Parse(string input)
	{
		var rows = input.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

		var gridArray = new SquareContent?[rows.Length][];
		for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
		{
			gridArray[rowIndex] = rows[rowIndex].Select(ParseCharacter).ToArray();
		}

		return new Grid(gridArray);
	}

	private static (int X, int Y)? FindGuardPosition(SquareContent?[][] grid)
	{
		for (var rowIndex = 0; rowIndex < grid.Length; rowIndex++)
		{
			var row = grid[rowIndex];
			for (var columnIndex = 0; columnIndex < row.Length; columnIndex++)
			{
				var squareContent = row[columnIndex];

				if (squareContent is SquareContent.GuardEast or SquareContent.GuardWest or SquareContent.GuardNorth or SquareContent.GuardSouth)
					return (columnIndex, rowIndex);
			}
		}
		return null;
	}

	private static SquareContent? ParseCharacter(char character)
	{
		return character switch
		{
			'.' => null,
			'#' => SquareContent.Obstacle,
			'^' => SquareContent.GuardNorth,
			'v' => SquareContent.GuardSouth,
			'>' => SquareContent.GuardEast,
			'<' => SquareContent.GuardWest,
			_ => throw new ArgumentException($"Invalid character '{character}'.")
		};
	}

	private static char CharacterToString(SquareContent? squareContent)
	{
		return squareContent switch
		{
			null => '.',
			SquareContent.Obstacle => '#',
			SquareContent.GuardNorth => '^',
			SquareContent.GuardSouth => 'v',
			SquareContent.GuardEast => '>',
			SquareContent.GuardWest => '<',
			_ => throw new ArgumentException($"Invalid SquareContent '{squareContent.ToString()}'.")
		};
	}

	public enum SquareContent
	{
		Obstacle,
		GuardNorth,
		GuardSouth,
		GuardEast,
		GuardWest,
	}
}
