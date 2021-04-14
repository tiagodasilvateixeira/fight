using Controllers;
using UnityEngine;

public class JumpState : PlayerState 
{
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
            CheckIdleState();
        }
        CheckWalkStateCommand();
    }
}