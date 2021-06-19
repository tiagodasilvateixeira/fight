using Controllers;
using UnityEngine;

namespace States
{
    public class WalkState : CharacterState
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
            CharacterStateSetter.CheckIdleState();
            CharacterStateSetter.CheckJumpCommand();
            CharacterStateSetter.CheckPunchCommand();
            CharacterStateSetter.CheckKickCommand();
            CharacterStateSetter.CheckBlockCommand();

            PlayerController.Walk();
        }
    }
}