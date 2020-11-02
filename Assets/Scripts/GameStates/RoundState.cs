using UnityEngine;

public class RoundState : GameState 
{
    

    public RoundState(GameController gameController): base(gameController)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Enter to the RoundState");
    }

    public override void Update() 
    {
        
    }
}