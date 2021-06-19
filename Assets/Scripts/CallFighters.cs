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

            Character characterPlayerOne = fighterPlayerOne.GetComponent<Character>();
            Character characterPlayerTwo = fighterPlayerTwo.GetComponent<Character>();

            InputController input = GetComponent<InputController>();
            characterPlayerOne.SetCharacterInput(input);
            characterPlayerTwo.SetCharacterInput(input);
        }
    }
}