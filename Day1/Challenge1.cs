namespace Day1;

public class Challenge1
{
    public int ReconcileLists(int[] listA, int[] listB)
    {
        listA = listA.OrderBy(x => x).ToArray();
        listB = listB.OrderBy(x => x).ToArray();

        return listA.Select((t, i) => Math.Abs(t - listB[i])).Sum();
    }
}
