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
        private GameObject fighterPlayerOne;
        private GameObject fighterPlayerTwo;

        void Start()
        {
            fighterPlayerOne = Instantiate(FighterPlayerOne);
            fighterPlayerTwo = Instantiate(FighterPlayerTwo);

            SetFightersPosition();
            SetFightersControllers();
            SetFightersMasks();
            SetFightersLayer();
            SetFightersEnemy();
            AddFightersToTargetGroup();
        }

        void SetFightersPosition()
        {
            fighterPlayerOne.GetComponent<Transform>().position = new Vector3(-6, -2.5f, 0);
            fighterPlayerTwo.GetComponent<Transform>().position = new Vector3(6, -2.5f, 0);
        }

        void SetFightersControllers()
        {
            fighterPlayerOne.AddComponent<InputController>();
            fighterPlayerTwo.AddComponent<PlayerTwoController>();
        }

        void SetFightersMasks()
        {
            fighterPlayerOne.GetComponent<Character>().HealthMask = playerOneMask;
            fighterPlayerTwo.GetComponent<Character>().HealthMask = playerTwoMask;
        }

        void SetFightersLayer()
        {
            fighterPlayerOne.layer = 8;
            fighterPlayerTwo.layer = 9;
        }

        void SetFightersEnemy()
        {
            fighterPlayerOne.GetComponent<Character>().SetEnemy(fighterPlayerTwo, "Fighter2");
            fighterPlayerTwo.GetComponent<Character>().SetEnemy(fighterPlayerOne, "Fighter1");
        }

        void AddFightersToTargetGroup()
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