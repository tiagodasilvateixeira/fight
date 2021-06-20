using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CharacterStateSetter
    {
        public IdleState Idle { get; set; }
        public WalkState Walk { get; set; }
        public JumpState Jump { get; set; }
        public PunchState Punch { get; set; }
        public KickState Kick { get; set; }
        public HitState Hit { get; set; }
        public BlockState Block { get; set; }

        public Character PlayerController { get; set; }
        public CharacterStateSetter(Character controller)
        {
            PlayerController = controller;
        }

        public void CheckIdleState()
        {
            if (!PlayerController.WalkInput())
            {
                Idle = new IdleState(PlayerController);
                PlayerController.SetState(Idle);
            }
        }
        public void CheckWalkCommand()
        {
            if (PlayerController.WalkInput())
            {
                Walk = new WalkState(PlayerController);
                PlayerController.SetState(Walk);
            }
        }
        public void CheckJumpCommand()
        {
            if (PlayerController.CharacterInput.GetJumpCommand() && PlayerController.Grounded)
            {
                Jump = new JumpState(PlayerController);
                PlayerController.SetState(Jump);
            }
        }
        public void CheckPunchCommand()
        {
            if (PlayerController.CharacterInput.GetPunchCommand())
            {
                Punch = new PunchState(PlayerController);
                PlayerController.SetState(Punch);
            }
        }
        public void CheckKickCommand()
        {
            if (PlayerController.CharacterInput.GetKickCommand())
            {
                Kick = new KickState(PlayerController);
                PlayerController.SetState(Kick);
            }
        }

        public void CheckBlockCommand()
        {
            if (PlayerController.CharacterInput.GetBlockCommand())
            {
                Block = new BlockState(PlayerController);
                PlayerController.SetState(Block);
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