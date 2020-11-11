using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerState : GameState 
{
    SelectPlayerController Controller;

    public SelectPlayerState(SelectPlayerController gameController): base(gameController)
    {
        Controller = gameController;
    }

    public SelectPlayerState()
    {
    }

    public override void EnterState()
    {
        Debug.Log("At SelectPlayerState");
    }

    public override void Update() 
    {
        if (Controller.GoToStartFight)
        {
            Controller.StartFight();
        }
        if (Controller.GoToBackToMenu)
        {
            Controller.BackToMenu();
        }
    }
}