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
        public GameObject RyuGameObject;
        public GameObject BlankaGameObject;
        PlayerController Player1;
        PlayerController Player2;
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
        Rounds = new Round[RoundsCount];
        SetPlayerCharacter();
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
        Player1.IA = false;
        Player1.transform.position = new Vector3(-6f, -2.5f, 0f);
        Player2.IA = true;
        Player2.transform.position = new Vector3(6f, -2.5f, 0f);
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
