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
        SetGroundedAnimator();
        if (!PlayerController.WalkInput() && PlayerController.grounded)
        {
            Idle = new IdleState(PlayerController);
            PlayerController.SetState(Idle);
        }
        if (PlayerController.WalkInput() && PlayerController.grounded)
        {
            Walk = new WalkState(PlayerController);
            PlayerController.SetState(Walk);
        }        
    }

    void SetGroundedAnimator()
    {
        if (Physics2D.Raycast(PlayerController.transform.position, Vector3.down, PlayerController.GroundDistance, PlayerController.GroundLayer))
        {
            PlayerController.animator.SetBool("grounded", true);
            PlayerController.grounded = true;
        }
        else
        {
            PlayerController.animator.SetBool("grounded", false);
            PlayerController.grounded = false;
        }
    }
}