using UnityEngine;

public class RoundMenuState : GameState 
{
    

    public RoundMenuState(GameController gameController): base(gameController)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Enter to the RoundMenuState");
    }

    public override void Update() 
    {
        
    }
}