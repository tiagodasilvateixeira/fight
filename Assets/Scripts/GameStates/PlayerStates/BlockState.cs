using Controllers;
using UnityEngine;

namespace States
{
    public class BlockState : PlayerState
    {
        public BlockState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Debug.Log($"{PlayerController.Name} in BlockState");
        }
        public override void Update()
        {
            CheckIdleState();
            CheckWalkCommand();
            CheckJumpCommand();
            CheckPunchCommand();
            CheckKickCommand();

            PlayerController.Block();
        }
    }
}