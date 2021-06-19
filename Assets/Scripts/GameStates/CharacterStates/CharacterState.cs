using Controllers;
using UnityEngine;

namespace States
{
    public abstract class CharacterState
    {
        public Character PlayerController { get; set; }
        public CharacterStateSetter CharacterStateSetter { get; set; }

        protected CharacterState(Character controller)
        {
            PlayerController = controller;
            CharacterStateSetter = new CharacterStateSetter(PlayerController);
        }

        public abstract void EnterState();
        public abstract void Update();
    }
}