using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.UI;

namespace Game
{
    public class CallFighters : MonoBehaviour
    {
        [SerializeField]
        private GameObject FighterPlayerOne;
        [SerializeField]
        private GameObject FighterPlayerTwo;
        [SerializeField]
        private GameObject CameraTargetGroup;
        [SerializeField]
        private Mask playerOneMask;
        [SerializeField]
        private Mask playerTwoMask;

        void Start()
        {
            GameObject fighterPlayerOne = Instantiate(FighterPlayerOne);
            GameObject fighterPlayerTwo = Instantiate(FighterPlayerTwo);

            SetFightersControllers(fighterPlayerOne, fighterPlayerTwo);
            SetFightersMasks(fighterPlayerOne, fighterPlayerTwo);
            SetFightersLayer(fighterPlayerOne, fighterPlayerTwo);
            SetFightersEnemy(fighterPlayerOne, fighterPlayerTwo);
            AddFightersToTargetGroup(fighterPlayerOne, fighterPlayerTwo);
        }

        void SetFightersControllers(GameObject playerOne, GameObject playerTwo)
        {
            playerOne.AddComponent<InputController>();
            playerTwo.AddComponent<PlayerTwoController>();
        }

        void SetFightersMasks(GameObject playerOne, GameObject playerTwo)
        {
            playerOne.GetComponent<Character>().HealthMask = playerOneMask;
            playerTwo.GetComponent<Character>().HealthMask = playerTwoMask;
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

        void AddFightersToTargetGroup(GameObject fighterPlayerOne, GameObject fighterPlayerTwo)
        {
            CinemachineTargetGroup.Target[] targets = { CreateTargetForTargetGroup(fighterPlayerOne), CreateTargetForTargetGroup(fighterPlayerTwo) };
            CameraTargetGroup.GetComponent<CinemachineTargetGroup>().m_Targets = targets;
        }

        CinemachineTargetGroup.Target CreateTargetForTargetGroup(GameObject fighter)
        {
            CinemachineTargetGroup.Target target = new CinemachineTargetGroup.Target
            {
                target = fighter.transform,
                radius = 1,
                weight = 1
            };

            return target;
        }
    }
}