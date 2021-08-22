using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class Round : MonoBehaviour
    {
        [SerializeField]
        private int NumberOfRounds;
        [SerializeField]
        private GameObject FightPanel;
        private FightPanel Panel;
        private bool RoundInitiated = false;
        private int NumberOfRoundsClosed;
        public Character CharacterPlayerOne
        {
            get
            {
                return CallFighters.Instance.CharacterPlayerOne;
            }
        }
        public Character CharacterPlayerTwo
        {
            get
            {
                return CallFighters.Instance.CharacterPlayerTwo;
            }
        }

        void Start()
        {
            SetFightPanel();
            InitializeRound();
        }

        private void SetFightPanel()
        {
            Panel = FightPanel.GetComponent<FightPanel>();
        }

        private void InitializeRound()
        {
            RoundInitiated = true;
            InitializeCharactersLife();
            InitializeFightPanelTimer();
        }

        private void InitializeCharactersLife()
        {
            CharacterPlayerOne.SetHealth(100);
            CharacterPlayerTwo.SetHealth(100);
        }

        private void InitializeFightPanelTimer()
        {
            Panel.InitCounter(90);
        }

        void Update()
        {
            if (RoundInitiated)
            {
                CloseRoundIfPanelTimerEqual0();
                CloseRoundIfAPlayerLifeEqual0();
            }
            else if (NumberOfRoundsClosed < NumberOfRounds)
                InitializeRound();
            else
                CloseFight();
        }

        private void CloseRoundIfPanelTimerEqual0()
        {
            if (Panel.CounterEqual0())
                CloseRound();
        }

        private void CloseRoundIfAPlayerLifeEqual0()
        {
            if (CharacterPlayerOne.Life <= 0 || CharacterPlayerTwo.Life <= 0)
                CloseRound();
        }

        void CloseRound()
        {
            FlagCharacterWinner();
            SetRoundClosed();
        }

        private void FlagCharacterWinner()
        {
            int maxLife = Math.Max(CharacterPlayerOne.Life, CharacterPlayerTwo.Life);
            if (maxLife == CharacterPlayerOne.Life)
                Panel.FlagPlayerToggle(1);
            else
                Panel.FlagPlayerToggle(2);
        }

        void SetRoundClosed()
        {
            RoundInitiated = false;
            NumberOfRoundsClosed++;
        }

        private void CloseFight()
        {
            DisableCharactersInput();
        }

        private void DisableCharactersInput()
        {
            CharacterPlayerOne.CharacterInput.Enabled = false;
            CharacterPlayerTwo.CharacterInput.Enabled = false;
        }
    }

}