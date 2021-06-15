using Controllers;
using UnityEngine;

namespace States
{
    public class PunchState : PlayerState
    {
        public PunchState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Debug.Log($"{PlayerController.Name} in PunchState");
            PlayerController.Punch();
        }

        public override void Update()
        {
            CheckIdleState();
            CheckWalkCommand();
        }
    }
}