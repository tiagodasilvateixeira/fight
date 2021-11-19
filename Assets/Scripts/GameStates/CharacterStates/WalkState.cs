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
            Demage = 0;
            Debug.Log($"{PlayerController.Name} in WalkState");
        }

        public override void Update()
        {
            CharacterStateSetter.CheckIdleState();
            CharacterStateSetter.CheckJumpCommand();
            CharacterStateSetter.CheckPunchCommand();
            CharacterStateSetter.CheckKickCommand();
            CharacterStateSetter.CheckBlockCommand();
            CharacterStateSetter.CheckEspecialAtackCommand();

            PlayerController.Walk();
        }
    }
}