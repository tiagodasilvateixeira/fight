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
            Delay = 0.3f;
            NextStateTime = Time.time + Delay;

            Debug.Log($"{PlayerController.Name} in PunchState");
            PlayerController.Punch();
        }

        public override void Update()
        {
            if (Time.time >= NextStateTime)
            {
                CharacterStateSetter.CheckIdleState();
                CharacterStateSetter.CheckWalkCommand();
            }
        }
    }
}