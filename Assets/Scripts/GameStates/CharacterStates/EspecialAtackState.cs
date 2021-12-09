using Controllers;
using States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class EspecialAtackState : CharacterState
    {
        public EspecialAtackState(Character playerController) : base(playerController)
        {
            PlayerController = playerController;
        }

        public override void EnterState()
        {
            Demage = 30;

            Debug.Log($"{PlayerController.Name} in EspecialAtackState");
            PlayerController.EspecialAtack();
        }

        public override void Update()
        {
            if (PlayerController.especialAtackTriggered == false)
            {
                CharacterStateSetter.CheckIdleState();
                CharacterStateSetter.CheckWalkCommand();
            }
        }
    }
}