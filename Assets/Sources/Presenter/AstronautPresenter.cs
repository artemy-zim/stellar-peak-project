using System.Collections.Generic;

public class AstronautPresenter
{
    private readonly AstronautCardListView _view;
    private readonly AstronautGenerator _generator;

    public AstronautPresenter(AstronautCardListView view, AstronautGenerator generator)
    {
        _view = view;
        _generator = generator;
    }

    public void GenerateAstronauts(int count)
    {
        List<AstronautCard> astronauts = _generator.GenerateAstronauts(count);
        GameSession.Instance.SaveAstronauts(astronauts);
        _view.RenderCards(astronauts);
    }
}
