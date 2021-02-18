using UnityEngine;

public class BlockState : PlayerState 
{
    public BlockState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in BlockState");
    }
    public override void Update() 
    {
        CheckIdleState();
        CheckWalkStateCommand();
        CheckJumpStateCommand();
        CheckPunchStateCommand();
        CheckKickStateCommand();

        PlayerController.Block();
    }
}