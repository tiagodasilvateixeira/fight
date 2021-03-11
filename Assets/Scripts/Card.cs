public static class Card
{
    public static string Player1Fighter { get; private set; }
    public static string Player2Fighter 
    { 
        get { return GetPlayer2Name(); }
    }

    public static void SetPlayer1Fighter(string fighterName)
    {
        Player1Fighter = fighterName;
    }

    static string GetPlayer2Name()
    {
        foreach (var name in PlayersCatalog.Players)
        {
            if (name != Card.Player1Fighter)
                return name;
        }
        return "";
    }
}
