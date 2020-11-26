using UnityEngine;

public class HitState : PlayerState 
{
    public HitState(PlayerController playerController): base(playerController)
    {
        PlayerController = playerController;
    }

    public override void EnterState()
    {
        Debug.Log($"{PlayerController.Name} in HitState");
        PlayerController.Hit();
        SetIdleState();
    }
    public override void Update() 
    {
        Debug.Log($"{PlayerController.Name} in HitState");
    }
}