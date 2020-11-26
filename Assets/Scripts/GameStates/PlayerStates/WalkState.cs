using UnityEngine;

public class WalkState : PlayerState 
{
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
        CheckIdleState();
        CheckJumpStateCommand();
        CheckPunchStateCommand();
        CheckKickStateCommand();

        PlayerController.Walk();
    }
}