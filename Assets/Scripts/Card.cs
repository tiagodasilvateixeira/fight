using System;
using System.Text;

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
        public static int CurrentRound { get; private set; }
        readonly static int Rounds = 3;

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

        public static void CreateRounds()
        {
            FightRounds = new Round[Rounds];
        }

        public static void InitCurrentRound()
        {
            FightRounds[CurrentRound] = new Round(CurrentRound);
        }

        public static bool FightIsOpen()
        {
            if (APlayerWinTwoRounds())
                return false;
            if (IsInitiatedFirstRound() || IsUnfinishedSecondRound() || EachPlayerWinOneRound())
                return true;
            return false;
        }

        static bool APlayerWinTwoRounds()
        {
            if (CurrentRound == 2 && FightRounds[2].Winner != string.Empty)
                return true;
            return false;
        }

        static bool IsInitiatedFirstRound()
        {
            if (CurrentRound == 0 && CurrentRoundIsInitiated())
                return true;
            return false;
        }

        static bool IsUnfinishedSecondRound()
        {
            if (CurrentRound == 1 && CurrentRoundIsInitiated() && !CurrentRoundHasAWinner())
                return true;
            return false;
        }

        static bool EachPlayerWinOneRound()
        {
            if (CurrentRound != 0 && CurrentRoundIsInitiated() && CurrentRoundHasAWinner() && GetLastRoundWinner() != FightRounds[CurrentRound].Winner)
                return true;
            return false;
        }

        static bool CurrentRoundIsInitiated()
        {
            if (FightRounds[CurrentRound] != null)
                return true;
            return false;
        }

        static bool CurrentRoundHasAWinner()
        {
            if (FightRounds[CurrentRound].Winner != null)
                return true;
            return false;
        }

        public static string GetLastRoundWinner()
        {
            int lastRoundNumber = GetLastRoundNumber();

            return FightRounds[lastRoundNumber]?.Winner;
        }

        static int GetLastRoundNumber()
        {
            if (CurrentRound - 1 < 0)
            {
                return 0;
            }
            else
            {
                return CurrentRound - 1;
            }
        }

        public static void SetCurrentRoundWinner(string winner)
        {
            FightRounds[CurrentRound].Winner = winner;
        }

        public static void AddCurrentRoundNumber()
        {
            CurrentRound++;
        }

        public static string GetFightWinner()
        {
            string lastRoundWinner = GetLastRoundWinner();
            if (string.IsNullOrWhiteSpace(lastRoundWinner))
                return string.Empty;

            if (FightRounds[0]?.Winner == FightRounds[1]?.Winner || FightRounds[0]?.Winner == FightRounds[2]?.Winner)
                return FightRounds[0].Winner;
            else
                return FightRounds[1].Winner;
        }

        public static void FinishFight()
        {
            Array.Clear(FightRounds, 0, FightRounds.Length);
            CurrentRound = 0;
        }
    }
}