using UnityEngine;

public class WalkState : PlayerState 
{
    #region states to transition
        PlayerState Idle;
        PlayerState Jump;
        PlayerState Punch;
    #endregion
    public WalkState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in WalkState");
    }

    public override void Update() 
    {
        if (!PlayerController.WalkInput())
        {
            Idle = new IdleState(PlayerController);
            PlayerController.SetState(Idle);
        }
        if (Input.GetButtonDown("Jump") && PlayerController.grounded && (PlayerController.IA == false))
        {
            Jump = new JumpState(PlayerController);
            PlayerController.SetState(Jump);
        }
        if (Input.GetKeyDown(KeyCode.J) && (PlayerController.IA == false))
        {
            Punch = new PunchState(PlayerController);
            PlayerController.SetState(Punch);
        }
        PlayerController.Walk();
    }
}