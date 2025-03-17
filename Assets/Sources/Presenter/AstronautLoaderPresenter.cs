using System.Collections.Generic;

public class AstronautLoaderPresenter 
{
    public AstronautLoaderPresenter(List<AstronautCardListView> views)
    {
        foreach(AstronautCardListView list in views)
        {
            list.RenderCards(GameSession.Instance.AstronautCards);
        }
    }
}
