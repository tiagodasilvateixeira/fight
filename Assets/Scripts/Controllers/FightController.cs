using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightController: GameController
{

    #region public proprierts
        public string Music { get; private set; }
        public bool GamePaused { get; set; }
        public GameObject MenuPanel;
    #endregion

    #region states
        protected GameState FightState;
    #endregion

    private void Start() 
    {
        ResumeGame();
        FightState = new FightState(this);
        SetState(FightState);
    }

    private void Update() 
    {
        GameState.Update();
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

    public void BackToMenu()
    {
        GamePaused = false;
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
