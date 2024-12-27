namespace Day5;

public class Challenge2(Dictionary<int, SortedSet<int>> DependenciesGraph)
{
	public int Solve(IEnumerable<int[]> pageLists)
	{
		return pageLists
			.Select(Order)
			.Select(pages => pages[pages.Length / 2])
			.Sum();
	}

	public int[] Order(int[] pageNumbers)
	{
		// Do an insertion sort of the page numbers
		// Where pages are inserted directly after the last page they depend upon
		var orderedPages = new List<int>() { pageNumbers[0] };
		foreach (var pageToInsert in pageNumbers.Skip(1))
		{
			var inserted = false;

			for (var i = orderedPages.Count - 1; i >= 0; i--)
			{
				var pageToInsertDependencies = BuildDependencySet(pageToInsert);

				// Check if the page to insert has a dependency on the current page
				// if (HasDependency(pageToInsert, orderedPages[i]))
				if (pageToInsertDependencies.Contains(orderedPages[i]))
				{
					// Insert after the current page
					orderedPages.Insert(i + 1, pageToInsert);
					inserted = true;
					break;
				}
			}

			if (inserted) continue;

			// Has no dependencies already in the array
			// Insert at the start of the list
			orderedPages.Insert(0, pageToInsert);
		}

		return orderedPages.ToArray();
	}

	private HashSet<int> BuildDependencySet(int pageNumber)
	{
		var res = new HashSet<int>() { };
		var toExplore = new Queue<int>();
		toExplore.Enqueue(pageNumber);

		while (toExplore.Count > 0)
		{
			var val = toExplore.Dequeue();

			if (val != pageNumber || res.Count > 0)
			{
				if (!res.Add(val)) continue;
			}

			// No dependencies
			if (!DependenciesGraph.TryGetValue(pageNumber, out var directDependencies))
				continue;

			foreach (var i in directDependencies)
			{
				res.Add(i);
			}
		}
		return res;
	}
}
