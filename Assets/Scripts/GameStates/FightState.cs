using UnityEngine;

public class FightState : GameState 
{
    FightController Controller;
    public FightState(FightController gameController): base(gameController)
    {
        Controller = gameController;
    }

    public override void EnterState()
    {
        Debug.Log("At FightState");
    }

    public override void Update() 
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Controller.GamePaused)
            {
                Controller.ResumeGame();
            }
            else
            {
                Controller.PauseGame();
            }
        }
        if (Controller.GoToBackToMenu)
        {
            Controller.BackToMenu();
        }
    }
}