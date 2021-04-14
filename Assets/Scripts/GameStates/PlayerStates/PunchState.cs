using Controllers;
using UnityEngine;

public class PunchState : PlayerState 
{
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
        CheckIdleState();
        CheckWalkStateCommand();       
    }
}