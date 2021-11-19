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
            Debug.Log($"{PlayerController.Name} in EspecialAtackState");
            PlayerController.EspecialAtack();
        }

        public override void Update()
        {
            CharacterStateSetter.CheckIdleState();
            CharacterStateSetter.CheckWalkCommand();
        }
    }
}