using Controllers;
using UnityEngine;

namespace States
{
    public class HitState : CharacterState
    {
        float Value;
        Vector3 Direction;

        public HitState(Character playerController, float force, Vector3 direction) : base(playerController)
        {
            PlayerController = playerController;
            Value = force;
            Direction = direction;
        }

        public override void EnterState()
        {
            Demage = 0;

            Debug.Log($"{PlayerController.Name} in HitState");
            PlayerController.Hit(Value, Direction);
            CharacterStateSetter.SetIdleState();
        }
        public override void Update()
        {
            Debug.Log($"{PlayerController.Name} in HitState");
        }
    }
}