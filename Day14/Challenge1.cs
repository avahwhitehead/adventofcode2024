namespace Day14;

public class Challenge1(int gridWidth, int gridHeight)
{
	private readonly Coord _gridDimensions = new(gridWidth, gridHeight);

	public int Solve(Robot[] robots, int numberOfSteps)
	{
		for (var stepCount = 0; stepCount < numberOfSteps; stepCount++)
		{
			Step(robots);
		}

		return CalculateSafetyFactor(robots);
	}

	public void Step(Robot[] robots)
	{
		foreach (var robot in robots)
		{
			Step(robot);
		}
	}

	public void Step(Robot robot)
	{
		robot.Position = new Coord(
			(robot.Position.X + robot.Velocity.X + _gridDimensions.X) % _gridDimensions.X,
			(robot.Position.Y + robot.Velocity.Y + _gridDimensions.Y) % _gridDimensions.Y
		);
	}

	public int CalculateSafetyFactor(Robot[] robots)
	{
		var topLeft = 0;
		var topRight = 0;
		var bottomLeft = 0;
		var bottomRight = 0;

		foreach (var robot in robots)
		{
			var position = robot.Position;

			// Ignore robots not in a quadrant
			if (gridWidth % 2 == 1 && position.X == gridWidth / 2) continue;
			if (gridHeight % 2 == 1 && position.Y == gridHeight / 2) continue;

			// Otherwise add to the quadrants position
			if (position.X < gridWidth / 2 && position.Y < gridHeight / 2) topLeft++;
			if (position.X > gridWidth / 2 && position.Y < gridHeight / 2) topRight++;
			if (position.X < gridWidth / 2 && position.Y > gridHeight / 2) bottomLeft++;
			if (position.X > gridWidth / 2 && position.Y > gridHeight / 2) bottomRight++;
		}

		return topLeft * topRight * bottomLeft * bottomRight;
	}
}
