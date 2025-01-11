using System.Text.RegularExpressions;

namespace Day14;

public static class Utils
{
	public static Robot[] ParseInput(string input)
	{
		var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

		var robots = new List<Robot>();

		foreach (var line in lines)
		{
			var lineRegex = new Regex(@"^p=(\d+),(\d+) +v=(-?\d+),(-?\d+)$");

			var match = lineRegex.Match(line);

			var positionX = int.Parse(match.Groups[1].Value);
			var positionY = int.Parse(match.Groups[2].Value);

			var velocityX = int.Parse(match.Groups[3].Value);
			var velocityY = int.Parse(match.Groups[4].Value);

			robots.Add(new Robot(
				new Coord(positionX, positionY),
				new Coord(velocityX, velocityY)
			));
		}

		return robots.ToArray();
	}
}


public class Robot
{
	public Robot(Coord position, Coord velocity)
	{
		Position = position;
		Velocity = velocity;
	}

	public Coord Position { get; set; }

	public Coord Velocity { get; }

	public override bool Equals(object? obj)
	{
		return obj is Robot robot && Position.Equals(robot.Position) && Velocity.Equals(robot.Velocity);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Velocity);
	}

	public override string ToString()
	{
		return $"[{Position}, {Velocity}]";
	}
}
