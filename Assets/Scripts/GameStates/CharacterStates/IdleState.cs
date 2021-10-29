using Controllers;
using UnityEngine;

namespace States
{
    public class IdleState : CharacterState
    {
        public IdleState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Demage = 0;

            Debug.Log($"{PlayerController.Name} in IdleState");
        }

        public override void Update()
        {
            if (PlayerController.CharacterInput.Enabled)
            {
                CharacterStateSetter.CheckWalkCommand();
                CharacterStateSetter.CheckJumpCommand();
                CharacterStateSetter.CheckPunchCommand();
                CharacterStateSetter.CheckKickCommand();
                CharacterStateSetter.CheckBlockCommand();
            }
            PlayerController.Idle();
        }
    }
}