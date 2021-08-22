using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.UI;

namespace Game
{
    public class CallFighters : MonoSingleton<CallFighters>
    {
        [SerializeField]
        private GameObject CameraTargetGroup;
        [SerializeField]
        private Mask playerOneMask;
        [SerializeField]
        private Mask playerTwoMask;
        [SerializeField]
        private GameObject fighterPlayerOne;
        [SerializeField]
        private GameObject fighterPlayerTwo;
        public Character CharacterPlayerOne
        {
            get
            {
                return fighterPlayerOne.GetComponent<Character>();
            }
        }
        public Character CharacterPlayerTwo
        {
            get
            {
                return fighterPlayerTwo.GetComponent<Character>();
            }
        }

        void Start()
        {
            fighterPlayerOne = Instantiate(fighterPlayerOne);
            fighterPlayerTwo = Instantiate(fighterPlayerTwo);

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
            fighterPlayerOne.AddComponent<PlayerOneInput>();
            fighterPlayerTwo.AddComponent<PlayerTwoInput>();
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