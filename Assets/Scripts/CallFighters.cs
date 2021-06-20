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

            fighterPlayerOne.AddComponent<InputController>();
            fighterPlayerTwo.AddComponent<PlayerTwoController>();
        }
    }
}