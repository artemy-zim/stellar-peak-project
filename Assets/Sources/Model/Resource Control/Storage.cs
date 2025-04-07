using System.Collections.Generic;
using System.Linq;

public class Storage
{
    private readonly List<Cell> _cells;
    public IReadOnlyList<IReadOnlyCell> Cells => _cells;

    public int ResourceScore { get; private set; }

    public Storage(int score)
    {
        ResourceScore = score;
        _cells = new List<Cell>();
    }

    public void Add(IEnumerable<IReadOnlyResource> resources)
    {
        using IEnumerator<IReadOnlyResource> enumerator = resources.GetEnumerator();

        while (enumerator.MoveNext())
        {
            IReadOnlyResource current = enumerator.Current;

            TryAddResource(current);
        }
    }

    public bool TrySpendResourceScore(int amount)
    {
        if (amount < 0 || ResourceScore - amount < 0)
            return false;

        ResourceScore -= amount;

        return true;
    }

    private void TryAddResource(IReadOnlyResource resource)
    {
        if (GameSession.Instance.SpaceBody.Resources.Any(resource => resource.ID.Equals(resource.ID) == false))
            return;

        ResourceScore += resource.Score;

        Cell newCell = new(resource);

        int cellIndex = _cells.FindIndex(cell => cell.Resource == resource);

        if (cellIndex == -1)
            _cells.Add(newCell);
        else
            _cells[cellIndex].Merge(newCell);
    }
}
