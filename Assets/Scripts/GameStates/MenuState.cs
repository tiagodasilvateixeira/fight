using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : GameState 
{
    MenuController Controller;
    public MenuState(MenuController gameController): base(gameController)
    {
        Controller = gameController;
    }

    public override void EnterState()
    {
        Debug.Log("At MenuState");
    }

    public override void Update()
    {
    }
}