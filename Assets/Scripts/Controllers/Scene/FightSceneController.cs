using Controllers;
using Fight;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class FightSceneController : MonoSingleton<FightSceneController>
    {
        public bool GamePaused { get; set; }
        public GameObject MenuPanel;
        public GameObject InitRoundPanel;
        public Mask MaskPlayer1;
        public Mask MaskPlayer2;
        PlayerController Player1;
        PlayerController Player2;
        private FightPanelController fightPanelController { get { return GameObject.Find("FightPanel").GetComponent<FightPanelController>(); } }
        private readonly int InitialRoundSeconds = 90;

        public void OpenScene()
        {
            SceneManager.LoadScene("FightScene", LoadSceneMode.Single);
        }

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "FightScene")
            {
                Card.CreateRounds();

                BindPlayerObjectToPlayerController();
                SetPlayersSceneComponentsToTheNextRound();
                InitRound();
            }
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "FightScene")
            {
                if (Card.FightIsOpen())
                {
                    if (APlayerHasNoLife())
                    {
                        string playerWithMoreLife = GetPlayerWithMoreLife();

                        Card.SetCurrentRoundWinner(playerWithMoreLife);
                        MarkRoundWinner(playerWithMoreLife);
                        SetPlayersSceneComponentsToTheNextRound();
                        if (Card.FightIsOpen())
                        {
                            Card.AddCurrentRoundNumber();
                            InitRound();
                        }
                    }
                }
                else
                {
                    FinishFight();
                }
            }
        }

        void BindPlayerObjectToPlayerController()
        {
            GameObject player1GameObject = GameObject.Find(Card.Player1Fighter);
            Player1 = player1GameObject.GetComponent<PlayerController>();
            GameObject player2GameObject = GameObject.Find(Card.Player2Fighter);
            Player2 = player2GameObject.GetComponent<PlayerController>();
        }

        void SetPlayersSceneComponentsToTheNextRound()
        {
            InitPlayersLife();
            SetPlayersMasks();
            InitPlayersMaskWidth();
            SetPlayersInputs();
            InitPlayersPositions();
        }

        void InitPlayersLife()
        {
            Player1.Life = 1f;
            Player2.Life = 1f;
        }

        void SetPlayersMasks()
        {
            Player1.SetHealtMask(MaskPlayer1);
            Player2.SetHealtMask(MaskPlayer2);
        }

        void InitPlayersMaskWidth()
        {
            Player1.SetHealth(Player1.Life);
            Player2.SetHealth(Player2.Life);
        }

        void SetPlayersInputs()
        {
            Player1.IA = false;
            Player2.IA = true;
        }

        void InitPlayersPositions()
        {
            Player1.transform.position = new Vector3(-6f, -2.5f, 0f);
            Player2.transform.position = new Vector3(6f, -2.5f, 0f);
        }

        void InitRound()
        {
            fightPanelController.InitCounter(InitialRoundSeconds);
            Card.InitCurrentRound();
        }

        bool APlayerHasNoLife()
        {
            if (Player1.Life <= 0 || Player2.Life <= 0)
                return true;
            return false;
        }

        private string GetPlayerWithMoreLife()
        {
            if (Player1.Life > Player2.Life)
            {
                return Player1.Name;
            }
            else if (Player2.Life > Player1.Life)
            {
                return Player2.Name;
            }
            else
            {
                return "Draw";
            }
        }

        void MarkRoundWinner(string winner)
        {
            if (winner == Player1.name)
            {
                fightPanelController.MarkToggle(fightPanelController.TogglePlayer1);
            }
            else
            {
                fightPanelController.MarkToggle(fightPanelController.TogglePlayer2);
            }
        }

        public void FinishFight()
        {
            string winner = Card.GetFightWinner();
            if (winner == Player1.Name)
            {
                Player1.Win();
                Player2.KO();
            }
            else
            {
                Player2.Win();
                Player1.KO();
            }

            Card.FinishFight();
            MenuSceneController.Instance.OpenScene();
        }

        public void HandlerInitRoundPanel(bool enableRoundPanel)
        {
            if (enableRoundPanel)
            {
                InitRoundPanel.SetActive(true);
            }
            else
            {
                InitRoundPanel.SetActive(false);
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            GamePaused = true;

            MenuPanel.SetActive(true);
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            GamePaused = false;

            MenuPanel.SetActive(false);
        }
    }
}