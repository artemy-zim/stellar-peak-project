public class Cell : IReadOnlyCell
{
    public IReadOnlyResource Resource { get; }
    public int Count { get; private set; }

    public Cell(IReadOnlyResource resource)
    {
        Resource = resource;
        Count = 1;
    }

    public void Merge(Cell newCell)
    {
        Count += newCell.Count;
    }
}
