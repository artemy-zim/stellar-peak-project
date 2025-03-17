public class ResourceLoaderPresenter
{
    public ResourceLoaderPresenter(ResourceCellListView view)
    {
        view.RenderCells(GameSession.Instance.Storage.Cells);
    }
}
