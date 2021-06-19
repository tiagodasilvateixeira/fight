using Controllers;
using UnityEngine;

namespace States
{
    public class KickState : CharacterState
    {
        public KickState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Debug.Log($"{PlayerController.Name} in KickState");
            PlayerController.Kick();
        }

        public override void Update()
        {
            CharacterStateSetter.CheckIdleState();
            CharacterStateSetter.CheckWalkCommand();
        }
    }
}