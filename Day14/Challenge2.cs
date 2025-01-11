namespace Day14;

public class Challenge2(int gridWidth, int gridHeight): Challenge1(gridWidth, gridHeight)
{
	/* For Challenge 2, I used the `Challenge2_Write_To_File` method I wrote to write consecutive
	 * steps to a file to see if I could manually spot the tree.
	 * However, while looking through the output, I realised that the robots would bunch together on a cycle.
	 * This turned out to be every 101st step after 89.
	 * This allowed me to optimise my code pretty quickly to reduce the number of iterations I needed to check.
	 * I was then able to find the drawing on step 91,494, however the website said this was too large.
	 * So I copied the diagram and added a method to check whether it exists in a given step,
	 * and that revealed the first answer of 8270.
	 */

	public int Solve(Robot[] robots)
	{
		int stepCount = 0;
		while (!IsChristmasTree(robots))
		{
			Step(robots);
			stepCount++;
		}

		return stepCount;
	}

	public bool IsChristmasTree(Robot[] robots)
	{
		var grid = DrawRobotRows(robots);

		string[] shape = [
			"###############################",
			"#                             #",
			"#                             #",
			"#                             #",
			"#                             #",
			"#              #              #",
			"#             ###             #",
			"#            #####            #",
			"#           #######           #",
			"#          #########          #",
			"#            #####            #",
			"#           #######           #",
			"#          #########          #",
			"#         ###########         #",
			"#        #############        #",
			"#          #########          #",
			"#         ###########         #",
			"#        #############        #",
			"#       ###############       #",
			"#      #################      #",
			"#        #############        #",
			"#       ###############       #",
			"#      #################      #",
			"#     ###################     #",
			"#    #####################    #",
			"#             ###             #",
			"#             ###             #",
			"#             ###             #",
			"#                             #",
			"#                             #",
			"#                             #",
			"#                             #",
			"###############################",
		];

		int shapeWidth = shape[0].Length;
		int shapeHeight = shape.Length;

		// Iterate over each row and column index in the grid
		for (var rowIndex = 0; rowIndex < GridDimensions.Y - shapeHeight; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < GridDimensions.X - shapeWidth; columnIndex++)
			{
				// Now see if the index lines up with the shape
				var isValid = true;
				for (var shapeRowIndex = 0; shapeRowIndex < shapeHeight; shapeRowIndex++)
				{
					for (var shapeColumnIndex = 0; shapeColumnIndex < shapeWidth; shapeColumnIndex++)
					{
						var gridRow = grid[rowIndex + shapeRowIndex];
						if (gridRow[columnIndex + shapeColumnIndex] != shape[shapeRowIndex][shapeColumnIndex])
						{
							isValid = false;
							break;
						}
					}
				}

				if (isValid)
				{
					return true;
				}
			}
		}

		return false;
	}

	public char[][] DrawRobotRows(Robot[] robots)
	{
		bool[][] grid = new bool[GridDimensions.Y][];
		for (int rowIndex = 0; rowIndex < GridDimensions.Y; rowIndex++)
		{
			grid[rowIndex] = new bool[GridDimensions.X];
		}

		foreach (var robot in robots)
		{
			var position = robot.Position;
			grid[position.Y][position.X] = true;
		}

		return grid
			.Select(row => row.Select(v => v ? "#" : " "))
			.Select(row => string.Join("", row))
			.Select(row => row.ToCharArray())
			.ToArray();
	}

	public string DrawRobots(Robot[] robots)
	{
		return DrawRobotRows(robots)
			.Select(row => string.Join("", row))
			.Aggregate((i, j) => i + "\n" + j);
	}
}
