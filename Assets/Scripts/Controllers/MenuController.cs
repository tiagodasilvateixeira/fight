using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: GameController
{
    protected GameState Menu;

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

    public void LoadSelectFightersScene()
    {
        SceneManager.LoadScene("FighterSelectorScene", LoadSceneMode.Single);
    }
}
