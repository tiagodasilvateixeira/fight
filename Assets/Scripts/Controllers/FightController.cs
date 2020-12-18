using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightController: GameController
{
    #region proprierts
        public bool GamePaused { get; set; }
        public bool GoToBackToMenu { get; set; }
        public GameObject MenuPanel;
        public GameObject InitRoundPanel;
        public GameObject RyuGameObject;
        public GameObject BlankaGameObject;
        public Image MaskPlayer1;
        public Image MaskPlayer2;
        public Text CounterText;
        public Text RoundText;
        public Round[] Rounds;
        PlayerController Player1;
        PlayerController Player2;
        private float SecondsToFinishRound;
        public float InitialRoundSeconds = 90.0f;
        public int RoundsCount = 2;
        public int CurrentRound = 1;
        private float SecondsToImproveRound = 5.0f;
    #endregion

    #region states
        protected GameState FightState;
    #endregion

    private void Start() 
    {
        FightState = new FightState(this);
        Rounds = new Round[RoundsCount];
        SetState(FightState);
        StartRound(CurrentRound);
        ResumeGame();
    }

    private void Update() 
    {
        Debug.Log($"{FightOpen()}");
        if (FightOpen())
        {
            UpdateTimer();
            CheckPlayerDefeat();
            CheckRoundSeconds();
            GameState.Update();
        }
    }

    bool FightOpen()
    {
        string winner = Rounds[CurrentRound]?.Winner;
        if (CurrentRound <= 2)
        {
            if (!string.IsNullOrWhiteSpace(winner))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    void SetPlayerCharacter()
    {
        if (PlayerSelected == RyuGameObject.GetComponent<PlayerController>().Name)
        {
            Player1 = RyuGameObject.GetComponent<PlayerController>();
            Player2 = BlankaGameObject.GetComponent<PlayerController>();
        }
        else if (PlayerSelected == BlankaGameObject.GetComponent<PlayerController>().Name)
        {
            Player1 = BlankaGameObject.GetComponent<PlayerController>();
            Player2 = RyuGameObject.GetComponent<PlayerController>();
        }
        Player1.Mask = MaskPlayer1;
        Player1.IA = false;
        Player1.transform.position = new Vector3(-6f, -2.5f, 0f);
        Player2.Mask = MaskPlayer2;
        Player2.IA = true;
        Player2.transform.position = new Vector3(6f, -2.5f, 0f);
    }

    public bool CheckRoundStarting()
    {
        Debug.Log($"SecondsToFinishRound + 3f: {(SecondsToFinishRound+3f).ToString()}");
        if (SecondsToFinishRound + 3f > InitialRoundSeconds)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DisablePlayersAfterRoundEnd()
    {
        Player1.IA = true;
        Player2.IA = true;
    }

    public void StartRound(int RoundNumber)
    {
        SetPlayerCharacter();
        Player1.Life = 1f;
        HealthBarController.instance.SetInitialMaskWidth(Player1.Mask);
        Player2.Life = 1f;
        HealthBarController.instance.SetInitialMaskWidth(Player2.Mask);

        SecondsToFinishRound = InitialRoundSeconds;
        Debug.Log($"RoundNumber: {RoundNumber}");
        Rounds[RoundNumber-1] = new Round(RoundNumber);
        Debug.Log($"Starting round: {CurrentRound}");
    }

    public void FinishRound(string character)
    {
        Rounds[CurrentRound-1].Winner = character;
        // DisablePlayersAfterRoundEnd();

        if (CurrentRound < RoundsCount)
        {
            CurrentRound++;
            StartRound(CurrentRound);
        }
    }

    public void UpdateTimer()
    {
        if (SecondsToFinishRound <= InitialRoundSeconds)
        {
            SecondsToFinishRound -= Time.deltaTime;
            CounterText.text = SecondsToFinishRound.ToString("0");
        }
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

    public void CheckRoundSeconds()
    {
        if (SecondsToFinishRound <= 0.0f)
        {
            string playerWithMoreLife = GetPlayerWithMoreLife();
            if (playerWithMoreLife != "Draw")
            {
                FinishRound(playerWithMoreLife);
            }
            else
            {
                SecondsToFinishRound = SecondsToImproveRound;
            }
        }
    }

    public void CheckPlayerDefeat()
    {
        if (Player1.Life <= 0)
        {
            FinishRound(GetPlayerWithMoreLife());
            Player1.animator.SetTrigger("ko");
        }
        else if (Player2.Life <= 0)
        {
            FinishRound(GetPlayerWithMoreLife());
            Player2.animator.SetTrigger("ko");
        }
    }

    public void HandlerInitRoundPanel(bool state)
    {
        if (state)
        {
            RoundText.text = $"Round {CurrentRound.ToString()}";
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
