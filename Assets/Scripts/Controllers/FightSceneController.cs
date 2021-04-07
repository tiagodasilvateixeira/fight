using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightSceneController: MonoSingleton<FightSceneController>
{
    public bool GamePaused { get; set; }
    public GameObject MenuPanel;
    public GameObject InitRoundPanel;
    public GameObject TogglePlayer1;
    public GameObject TogglePlayer2;
    public Mask MaskPlayer1;
    public Mask MaskPlayer2;
    public Text CounterText;
    public Round[] Rounds;
    PlayerController Player1;
    PlayerController Player2;
    private float SecondsToFinishRound;
    private float InitialRoundSeconds = 90.0f;
    private float SecondsToImproveRound = 5.0f;
    private float FinishTimer = 3.0f;
    private int RoundsCount = 3;
    private int CurrentRound = 0;

    public void OpenScene()
    {
        SceneManager.LoadScene("FightScene", LoadSceneMode.Single);
    }

    private void Start() 
    {
        if (SceneManager.GetActiveScene().name == "FightScene")
        {
            Rounds = new Round[RoundsCount];

            BindPlayerObjectToPlayerController();
            SetPlayersSceneComponentsToTheNextRound();
            StartRound();
        }
    }

    private void Update() 
    {
        if (SceneManager.GetActiveScene().name == "FightScene")
        {
            if (FightIsOpen())
            {
                RoundTimeIsOver();
                if (APlayerHasNoLife())
                {
                    SetRoundWinner(GetPlayerWithMoreLife());
                    SetPlayersSceneComponentsToTheNextRound();
                    if (FightIsOpen())
                    {
                        CurrentRound += 1;
                        StartRound();
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
        Player1.SetHealth(Player1.Life);
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

    void StartRound()
    {
        SecondsToFinishRound = InitialRoundSeconds;
        Rounds[CurrentRound] = new Round(CurrentRound+1);
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
        return true;
    }

    bool LastRoundIsOver()
    {
        if (string.IsNullOrWhiteSpace(Rounds[CurrentRound]?.Winner))
            return false;
        return true;
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

    public void SetRoundWinner(string character)
    {
        Rounds[CurrentRound].Winner = character;
        MarkRoundWinner();
    }

    void MarkRoundWinner()
    {
        if (Rounds[CurrentRound].Winner == Player1.name)
        {
            SetPlayerToggleOn(TogglePlayer1.GetComponent<Toggle>());
        }
        else if (Rounds[CurrentRound].Winner == Player2.name)
        {
            SetPlayerToggleOn(TogglePlayer2.GetComponent<Toggle>());
        }
    }

    void SetPlayerToggleOn(Toggle playerToggle)
    {
        playerToggle.isOn = true;
    }

    public void RoundTimeIsOver()
    {
        if (SecondsToFinishRound <= 0.0f)
        {
            string playerWithMoreLife = GetPlayerWithMoreLife();
            if (playerWithMoreLife != "Draw")
            {
                SetRoundWinner(playerWithMoreLife);
            }
            else
            {
                SecondsToFinishRound = SecondsToImproveRound;
            }
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
            // BackToMenu();
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
