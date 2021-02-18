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
        public GameObject TogglePlayer1;
        public GameObject TogglePlayer2;
        public Image MaskPlayer1;
        public Image MaskPlayer2;
        public Text CounterText;
        public Round[] Rounds;
        PlayerController Player1;
        PlayerController Player2;
        private float SecondsToFinishRound;
        public float InitialRoundSeconds = 90.0f;
        public int RoundsCount = 3;
        public int CurrentRound = 0;
        private float SecondsToImproveRound = 5.0f;
        private float FinishTimer = 3.0f;
    #endregion

    #region states
        protected GameState FightState;
    #endregion

    private void Start() 
    {
        FightState = new FightState(this);
        Rounds = new Round[RoundsCount];

        SetState(FightState);
        
        BindPlayerControllerToPlayerObject();
        SetInitialPlayersLife();
        SetInitialPlayersMaskWidth();
        InitializePlayersCharacters();
        StartRound(CurrentRound);
        ResumeGame();
    }

    private void Update() 
    {
        if (FightIsOpen())
        {
            UpdateTimer();
            if (APlayerDefeated())
            {
                FinishRound(GetPlayerWithMoreLife());
                SetInitialPlayersLife();
                SetInitialPlayersMaskWidth();
                InitializePlayersCharacters();
                if (FightIsOpen())
                {
                    StartRound(CurrentRound++);
                }
            }
            CheckRoundSeconds();
            GameState.Update();
        }
        else
        {
            FinishFight();
        }
    }

    void BindPlayerControllerToPlayerObject()
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
    }

    void SetInitialPlayersLife()
    {
        Player1.Life = 1f;
        Player2.Life = 1f;
    }

    void SetInitialPlayersMaskWidth()
    {
        HealthBarController.instance.SetInitialMaskWidth(Player1.Mask);
        HealthBarController.instance.SetInitialMaskWidth(Player2.Mask);
    }

    bool FightIsOpen()
    {
        if (ReturnTrueIfAFighterWinTwoRounds())
            return false;
        if (IsLastRound() && LastRoundIsOver())
            return false;
        return true;
    }

    bool ReturnTrueIfAFighterWinTwoRounds()
    {
        if (CurrentRound == 0 || CurrentRound == 1)
        {
            return false;
        }
        else if (Rounds[0]?.Winner == Rounds[CurrentRound-1]?.Winner)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsLastRound()
    {
        if (CurrentRound < RoundsCount)
            return false;
        Debug.Log("Is last round");
        return true;
    }

    bool LastRoundIsOver()
    {
        if (string.IsNullOrWhiteSpace(Rounds[CurrentRound]?.Winner))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    void InitializePlayersCharacters()
    {
        Player1.Mask = MaskPlayer1;
        Player1.IA = false;
        Player1.transform.position = new Vector3(-6f, -2.5f, 0f);
        Player2.Mask = MaskPlayer2;
        Player2.IA = true;
        Player2.transform.position = new Vector3(6f, -2.5f, 0f);
    }

    public bool RoundStarting()
    {
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

    void StartRound(int RoundNumber)
    {
        SecondsToFinishRound = InitialRoundSeconds;
        Rounds[RoundNumber] = new Round(RoundNumber+1);
    }

    public void FinishRound(string character)
    {
        Rounds[CurrentRound].Winner = character;
        if (character == Player1.name)
        {
            Toggle togglePlayer1 = TogglePlayer1.GetComponent<Toggle>();
            togglePlayer1.isOn = true;
        }
        else if (character == Player2.name)
        {
            Toggle togglePlayer2 = TogglePlayer2.GetComponent<Toggle>();
            togglePlayer2.isOn = true;
        }
    }

    public void FinishFight()
    {
        string winner = GetWinner();
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

        FinishTimer -= Time.deltaTime;
        if (FinishTimer < 0.0f)
        {
            BackToMenu();
        }
    }

    string GetWinner()
    {
        if (Rounds[0]?.Winner == Rounds[1]?.Winner)
        {
            return Rounds[0]?.Winner;
        }
        else if (Rounds[0]?.Winner == Rounds[2]?.Winner)
        {
            return Rounds[0]?.Winner;
        }
        else
        {
            return Rounds[1]?.Winner;
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

    bool APlayerDefeated()
    {
        if (Player1.Life <= 0 || Player2.Life <= 0)
            return true;
        return false;
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
