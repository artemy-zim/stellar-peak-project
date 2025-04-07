using System.Collections.Generic;

public class GameSession
{
    private static GameSession _instance;

    public static GameSession Instance => _instance ??= new GameSession();

    private Storage _storage;

    public PlaneterySystem SelectedSystem { get; private set; }
    public List<AstronautCard> AstronautCards { get; private set; }
    public AstronautCard ChosenAstronaut {  get; private set; }
    public SpaceBody SpaceBody { get; private set; }
    public Storage Storage => _storage ??= new Storage(0);

    public void SetSelectedSystem(PlaneterySystem system)
    {
        SelectedSystem = system;
    }

    public void SaveAstronauts(List<AstronautCard> cards)
    {
        AstronautCards = cards;
    }

    public void SetSelectedAstronaut(AstronautCard card)
    {
        ChosenAstronaut = card;
    }

    public void SetSelectedPlanet(SpaceBody planet)
    {
        SpaceBody = planet;
    }
}
