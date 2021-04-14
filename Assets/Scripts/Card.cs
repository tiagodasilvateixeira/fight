namespace Fight
{
    public static class Card
    {
        public static string Player1Fighter { get; private set; }
        public static string Player2Fighter
        {
            get { return GetPlayer2Name(); }
        }

        public static Round[] FightRounds { get; private set; }
        static int Rounds = 3;
        static int CurrentRound = 0;

        public static void SetPlayer1Fighter(string fighterName)
        {
            Player1Fighter = fighterName;
        }

        static string GetPlayer2Name()
        {
            foreach (var name in FightersCatalog.Players)
            {
                if (name != Player1Fighter)
                    return name;
            }
            return "";
        }

        public static void InitRounds()
        {
            FightRounds = new Round[Rounds];
        }
    }
}