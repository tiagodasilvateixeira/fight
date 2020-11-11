using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: GameController
{
    #region public attributes
        public string Music { get; private set; }
        public bool GoToSelectFighters { get; set; }
    #endregion

    #region states
        protected GameState Menu;
    #endregion

    private void Start() 
    {
        Menu = new MenuState(this);
        SetState(Menu);
    }

    private void Update() 
    {
        GameState.Update();
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

    public void SelectFighters() 
    {
        SceneManager.LoadScene("FighterSelectorScene", LoadSceneMode.Single);
    }
}
