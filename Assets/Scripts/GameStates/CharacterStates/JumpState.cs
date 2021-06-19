using Controllers;
using UnityEngine;

namespace States
{
    public class JumpState : CharacterState
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
                CharacterStateSetter.CheckIdleState();
            }
            CharacterStateSetter.CheckWalkCommand();
        }
    }
}