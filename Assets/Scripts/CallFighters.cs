using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CallFighters : MonoBehaviour
    {
        [SerializeField]
        private GameObject FighterPlayerOne;
        [SerializeField]
        private GameObject FighterPlayerTwo;

        void Start()
        {
            GameObject fighterPlayerOne = Instantiate(FighterPlayerOne);
            GameObject fighterPlayerTwo = Instantiate(FighterPlayerTwo);

            SetFightersControllers(fighterPlayerOne, fighterPlayerTwo);
            SetFightersLayer(fighterPlayerOne, fighterPlayerTwo);
            SetFightersEnemy(fighterPlayerOne, fighterPlayerTwo);
        }

        void SetFightersControllers(GameObject playerOne, GameObject playerTwo)
        {
            playerOne.AddComponent<InputController>();
            playerTwo.AddComponent<PlayerTwoController>();
        }

        void SetFightersLayer(GameObject playerOne, GameObject playerTwo)
        {
            playerOne.layer = 8;
            playerTwo.layer = 9;
        }

        void SetFightersEnemy(GameObject playerOne, GameObject playerTwo)
        {
            playerOne.GetComponent<Character>().SetEnemy(playerTwo, "Fighter2");
            playerTwo.GetComponent<Character>().SetEnemy(playerOne, "Fighter1");
        }
    }
}