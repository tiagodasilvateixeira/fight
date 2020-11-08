using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : GameState 
{
    MenuController Controller;
    public MenuState(MenuController gameController): base(gameController)
    {
        Controller = gameController;
        Controller.GoToSelectFighters = false;
    }

    public override void EnterState()
    {
        Debug.Log("At MenuState");
    }

    public override void Update() 
    {
        if (Controller.GoToSelectFighters)
        {
            SelectFighters();
        }
    }

    public void SelectFighters() 
    {
        SceneManager.LoadScene("FighterSelectorScene", LoadSceneMode.Single);
    }
}