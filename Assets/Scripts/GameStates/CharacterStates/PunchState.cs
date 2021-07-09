using Controllers;
using UnityEngine;

namespace States
{
    public class PunchState : CharacterState
    {
        public PunchState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Demage = 7;

            Debug.Log($"{PlayerController.Name} in PunchState");
            PlayerController.Punch();
        }

        public override void Update()
        {
            CharacterStateSetter.CheckIdleState();
            CharacterStateSetter.CheckWalkCommand();
        }
    }
}