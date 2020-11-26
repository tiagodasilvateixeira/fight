using UnityEngine;

public class KickState : PlayerState 
{
    public KickState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in KickState");
        PlayerController.Kick();
    }

    public override void Update() 
    {
        CheckIdleState();
        CheckWalkStateCommand();       
    }
}