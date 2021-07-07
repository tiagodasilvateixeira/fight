using Controllers;
using UnityEngine;

namespace States
{
    public class BlockState : CharacterState
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
            if (!PlayerController.CharacterInput.GetBlockCommand())
            {
                CharacterStateSetter.CheckIdleState();
                CharacterStateSetter.CheckWalkCommand();
                CharacterStateSetter.CheckJumpCommand();
                CharacterStateSetter.CheckPunchCommand();
                CharacterStateSetter.CheckKickCommand();
            }

            PlayerController.Block();
        }
    }
}