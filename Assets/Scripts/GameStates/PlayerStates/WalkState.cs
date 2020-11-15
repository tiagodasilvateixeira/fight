using UnityEngine;

public class WalkState : PlayerState 
{
    IPlayer Controller;
    public WalkState(IPlayer gameController): base(gameController)
    {
        Controller = gameController;
    }

    public override void EnterState()
    {
        Debug.Log($"{Controller.Name} in WalkState");
    }

    public override void Update() 
    {
    }
}