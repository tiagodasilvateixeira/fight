using Controllers;
using UnityEngine;

namespace States
{
    public class IdleState : PlayerState
    {
        public IdleState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Debug.Log($"{PlayerController.Name} in IdleState");
        }

        public override void Update()
        {
            CheckWalkCommand();
            CheckJumpCommand();
            CheckPunchCommand();
            CheckKickCommand();
            CheckBlockCommand();

            PlayerController.Idle();
        }
    }
}