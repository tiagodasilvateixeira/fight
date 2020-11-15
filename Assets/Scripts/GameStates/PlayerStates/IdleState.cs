using UnityEngine;

public class IdleState : PlayerState 
{
    #region states to transition
        PlayerState Walk;
    #endregion

    IPlayer Controller;
    public IdleState(IPlayer gameController): base(gameController)
    {
        Controller = gameController;
    }

    public override void EnterState()
    {
        Debug.Log($"{Controller.Name} in IdleState");
    }

    public override void Update() 
    {
        if (Controller.CheckWalkInput() && Controller.IA == false)
        {
            
        }
    }
}