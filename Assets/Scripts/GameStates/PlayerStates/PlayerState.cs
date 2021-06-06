using Controllers;
using UnityEngine;

namespace States
{
    public abstract class PlayerState
    {
        public IdleState Idle { get; set; }
        public WalkState Walk { get; set; }
        public JumpState Jump { get; set; }
        public PunchState Punch { get; set; }
        public KickState Kick { get; set; }
        public HitState Hit { get; set; }
        public BlockState Block { get; set; }

        public Character PlayerController { get; set; }
        public PlayerState(Character controller)
        {
        }
        public PlayerState()
        {
        }
        public abstract void EnterState();
        public abstract void Update();

        public void CheckIdleState()
        {
            if (!PlayerController.WalkInput() && (PlayerController.IA == false))
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
            if (PlayerController.WalkInput() && (PlayerController.IA == false))
            {
                Walk = new WalkState(PlayerController);
                PlayerController.SetState(Walk);
            }
        }
        public void CheckJumpStateCommand()
        {
            if (Input.GetButtonDown("Jump") && PlayerController.Grounded && (PlayerController.IA == false))
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

        public void CheckBlockStateCommand()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && (PlayerController.IA == false))
            {
                Block = new BlockState(PlayerController);
                PlayerController.SetState(Block);
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
        public void SetHitState(float force, Vector3 direction)
        {
            Hit = new HitState(PlayerController, force, direction);
            PlayerController.SetState(Hit);
        }
    }
}