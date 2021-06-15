using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CallFighters : MonoBehaviour
    {
        [SerializeField]
        private GameObject FighetrPlayerOne;
        [SerializeField]
        private GameObject FighetrPlayerTwo;

        void Start()
        {
            Instantiate(FighetrPlayerOne);
            Instantiate(FighetrPlayerTwo);
        }
    }
}