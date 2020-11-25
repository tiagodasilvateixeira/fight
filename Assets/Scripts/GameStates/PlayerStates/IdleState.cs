using UnityEngine;

public class IdleState : PlayerState 
{
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
        CheckWalkStateCommand();
        CheckJumpStateCommand();
        CheckPunchStateCommand();
        
        PlayerController.Idle();
    }
}