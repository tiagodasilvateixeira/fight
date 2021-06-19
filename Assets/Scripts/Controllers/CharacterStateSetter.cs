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
            if (Input.GetButtonDown("Jump") && PlayerController.Grounded)
            {
                Jump = new JumpState(PlayerController);
                PlayerController.SetState(Jump);
            }
        }
        public void CheckPunchCommand()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Punch = new PunchState(PlayerController);
                PlayerController.SetState(Punch);
            }
        }
        public void CheckKickCommand()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Kick = new KickState(PlayerController);
                PlayerController.SetState(Kick);
            }
        }

        public void CheckBlockCommand()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
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