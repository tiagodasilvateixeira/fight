using UnityEngine;

namespace Fight
{
    public class Round
    {
        public int Number { get; private set; }
        public string Winner { get; set; }

        public Round(int number)
        {
            Number = number;
            Winner = "";
        }
    }
}