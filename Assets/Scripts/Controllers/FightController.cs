using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightController: GameController
{

    #region proprierts
        public string Music { get; private set; }
        public bool GamePaused { get; set; }
        public bool GoToBackToMenu { get; set; }
        public GameObject MenuPanel;
        public GameObject Player1GameObject;
        public GameObject Player2GameObject;
        public PlayerController Player1;
        public PlayerController Player2;
        public Text CounterText;
        public float InitialRoundSeconds = 90.0f;
        public int RoundsCount = 3;
        public Round[] Rounds;
        public int CurrentRound = 1;
        private float SecondsToFinishRound;
        private float SecondsToImproveRound = 5.0f;
    #endregion

    #region states
        protected GameState FightState;
    #endregion

    private void Start() 
    {
        FightState = new FightState(this);
        SecondsToFinishRound = InitialRoundSeconds;
        Player1 = Player1GameObject.GetComponent<PlayerController>();
        Player2 = Player2GameObject.GetComponent<PlayerController>();
        Rounds = new Round[RoundsCount];
        SetState(FightState);
        StartRound(CurrentRound);
        ResumeGame();
    }

    private void Update() 
    {
        UpdateTimer();
        CheckRoundSeconds();
        GameState.Update();
    }

    public void StartRound(int RoundNumber)
    {
        Rounds[RoundNumber] = new Round(RoundNumber);
    }

    public void EndRound(string character)
    {
        Rounds[CurrentRound].Winner = character;
        CurrentRound++;

        StartRound(CurrentRound);
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
                EndRound(playerWithMoreLife);
            }
            else
            {
                SecondsToFinishRound = SecondsToImproveRound;
            }
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
