using UnityEngine;

public class JumpState : PlayerState 
{
    #region states to transition
        PlayerState Idle;
        PlayerState Walk;
    #endregion
    public JumpState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in JumpState");
        PlayerController.Jump();
    }

    public override void Update() 
    {
        if (PlayerController.grounded)
        {
            if (!PlayerController.WalkInput())
            {
                Idle = new IdleState(PlayerController);
                PlayerController.SetState(Idle);
            }
            
        }
        if (PlayerController.WalkInput())
        {
            Walk = new WalkState(PlayerController);
            PlayerController.SetState(Walk);
        } 
    }
}