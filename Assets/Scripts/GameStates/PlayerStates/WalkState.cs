using Controllers;
using UnityEngine;

namespace States
{
    public class WalkState : PlayerState
    {
        public WalkState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Debug.Log($"{PlayerController.Name} in WalkState");
        }

        public override void Update()
        {
            CheckIdleState();
            CheckJumpStateCommand();
            CheckPunchStateCommand();
            CheckKickStateCommand();
            CheckBlockStateCommand();

            PlayerController.Walk();
        }
    }
}