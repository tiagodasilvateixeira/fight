using UnityEngine;

public class PunchState : PlayerState 
{
    #region states to transition
        PlayerState Idle;
        PlayerState Walk;
    #endregion
    public PunchState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in PunchState");
        PlayerController.Punch();
    }

    public override void Update() 
    {
        if (!PlayerController.WalkInput())
        {
            Idle = new IdleState(PlayerController);
            PlayerController.SetState(Idle);
        }
        if (PlayerController.WalkInput())
        {
            Walk = new WalkState(PlayerController);
            PlayerController.SetState(Walk);
        }        
    }
}