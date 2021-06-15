using Controllers;
using UnityEngine;

namespace States
{
    public class JumpState : PlayerState
    {
        public JumpState(Character playerController) : base(playerController)
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
            if (PlayerController.Grounded)
            {
                CheckIdleState();
            }
            CheckWalkCommand();
        }
    }
}