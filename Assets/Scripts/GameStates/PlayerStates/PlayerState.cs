using UnityEngine;

public abstract class PlayerState
{
    public IdleState Idle;
    public WalkState Walk;
    public JumpState Jump;
    public PunchState Punch;
    public KickState Kick;
    public HitState Hit;
    
    public PlayerController PlayerController { get; set; }
    public PlayerState(PlayerController controller)
    {
    }
    public PlayerState()
    {
    }
    public abstract void EnterState();
    public abstract void Update();

    public void CheckIdleState()
    {
        if (!PlayerController.WalkInput())
        {
            Idle = new IdleState(PlayerController);
            PlayerController.SetState(Idle);
        }
        else if (PlayerController.IA == true)
        {
            
        }
    }
    public void CheckWalkStateCommand()
    {
        if (PlayerController.WalkInput())
        {
            Walk = new WalkState(PlayerController);
            PlayerController.SetState(Walk);
        }
    }
    public void CheckJumpStateCommand()
    {
        if (Input.GetButtonDown("Jump") && PlayerController.grounded && (PlayerController.IA == false))
        {
            Jump = new JumpState(PlayerController);
            PlayerController.SetState(Jump);
        }
        else if (PlayerController.IA == true)
        {
            
        }
    }
    public void CheckPunchStateCommand()
    {
        if (Input.GetKeyDown(KeyCode.J) && (PlayerController.IA == false))
        {
            Punch = new PunchState(PlayerController);
            PlayerController.SetState(Punch);
        }
        else if (PlayerController.IA == true)
        {

        }
    }
    public void CheckKickStateCommand()
    {
        if (Input.GetKeyDown(KeyCode.K) && (PlayerController.IA == false))
        {
            Kick = new KickState(PlayerController);
            PlayerController.SetState(Kick);
        }
        else if (PlayerController.IA == true)
        {

        }
    }

    public void SetIdleState()
    {
        Idle = new IdleState(PlayerController);
        PlayerController.SetState(Idle);
    }
    public void SetHitState(float value, Vector3 direction)
    {
        Hit = new HitState(PlayerController, value, direction);
        PlayerController.SetState(Hit);
    }
}