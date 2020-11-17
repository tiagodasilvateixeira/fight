using UnityEngine;

public class IdleState : PlayerState 
{
    #region states to transition
        PlayerState Walk;
        PlayerState Jump;
        PlayerState Punch;
    #endregion
    public IdleState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in IdleState");
    }

    public override void Update() 
    {
        if (PlayerController.WalkInput())
        {
            Walk = new WalkState(PlayerController);
            PlayerController.SetState(Walk);
        }
        if (Input.GetButtonDown("Jump") && PlayerController.grounded && (PlayerController.IA == false))
        {
            Jump = new JumpState(PlayerController);
            PlayerController.SetState(Jump);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Punch = new PunchState(PlayerController);
            PlayerController.SetState(Punch);
        }
        PlayerController.Idle();
    }
}