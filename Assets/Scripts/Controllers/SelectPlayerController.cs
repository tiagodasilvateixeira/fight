using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerController: GameController
{
    #region internal proprierts
        public string Music { get; private set; }
        public bool GoToStartFight { get; set; }
        public bool GoToBackToMenu { get; set; }
    #endregion

    #region states
        protected GameState SelectPlayerState;
    #endregion

    private void Start() 
    {
        SelectPlayerState = new SelectPlayerState(this);
        SetState(SelectPlayerState);
    }

    private void Update() 
    {
        GameState.Update();
    }

    public void SelectPlayer(string text)
    {
        PlayerSelected = text;
        Debug.Log($"Player selected: {text}");
        Debug.Log($"Player selected: {PlayerSelected}");
    }

    public void StartFight()
    {
        if (PlayerSelected != string.Empty)
        {
            SceneManager.LoadScene("FightScene", LoadSceneMode.Single);
        }
    }
}
