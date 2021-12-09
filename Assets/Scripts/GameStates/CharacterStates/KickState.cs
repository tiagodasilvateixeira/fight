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
            Demage = 10;
            Delay = 0.3f;
            NextStateTime = Time.time + Delay;

            Debug.Log($"{PlayerController.Name} in KickState");
            PlayerController.Kick();
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