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
        [SerializeField]
        private GameObject RoundPanel;
        private FightPanel FightPanelInstance;
        private bool RoundInitiated = false;
        private int NumberOfRoundsClosed;
        private string[] RoundWinner = new string[3];
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
            SetPanels();
            InitializeRound();
        }

        private void SetPanels()
        {
            FightPanelInstance = FightPanel.GetComponent<FightPanel>();
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
            FightPanelInstance.InitCounter(90);
        }

        private void Update()
        {
            if (RoundInitiated)
            {
                CloseRoundIfPanelTimerEqual0();
                CloseRoundIfAPlayerLifeEqual0();
            }
            else if ((NumberOfRoundsClosed < NumberOfRounds) && (RoundWinner?.GetValue(0) != RoundWinner?.GetValue(1)))
                InitializeRound();
            else
            {
                if (NumberOfRoundsClosed < NumberOfRounds)
                {
                    CloseRound();
                }
                CloseFight();
            }
                
        }

        private void CloseRoundIfPanelTimerEqual0()
        {
            if (FightPanelInstance.CounterEqual0())
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
            {
                FightPanelInstance.FlagPlayerToggle(1);
                RoundWinner.SetValue(CharacterPlayerOne.Name, NumberOfRoundsClosed);
            }
            else
            {
                FightPanelInstance.FlagPlayerToggle(2);
                RoundWinner.SetValue(CharacterPlayerTwo.Name, NumberOfRoundsClosed);
            }
                
        }

        void SetRoundClosed()
        {
            RoundInitiated = false;
            NumberOfRoundsClosed++;
        }

        private void CloseFight()
        {
            StartCoroutine(SetFinishedFightAnimationCharacters());
        }

        IEnumerator SetFinishedFightAnimationCharacters()
        {
            DisablePanels();
            DisableCharactersInput();
            SetCharactersAnimations();

            yield return new WaitForSeconds(4);

            LoadPreFightScene();
        }
        
        private void DisableCharactersInput()
        {
            CharacterPlayerOne.CharacterInput.Enabled = false;
            CharacterPlayerTwo.CharacterInput.Enabled = false;
        }

        private void DisablePanels()
        {
            FightPanel.SetActive(false);
            RoundPanel.SetActive(false);
        }

        private void SetCharactersAnimations()
        {
            if (GetWinnerName() == CharacterPlayerOne.Name)
            {
                CharacterPlayerOne.Win();
                CharacterPlayerTwo.KO();
            }
            else
            {
                CharacterPlayerTwo.Win();
                CharacterPlayerOne.KO();
            }
        }

        private string GetWinnerName()
        {
            if (RoundWinner?.GetValue(0) == RoundWinner?.GetValue(1))
                return RoundWinner.GetValue(0).ToString();
            else
                return RoundWinner.GetValue(2).ToString();
        }

        private void LoadPreFightScene()
        {
            Scene.Instance.NextScene = "InsultScene";
            Scene.Instance.LoadNextScene(UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}