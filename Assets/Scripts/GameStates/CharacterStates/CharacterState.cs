using Controllers;
using UnityEngine;

namespace States
{
    public abstract class CharacterState
    {
        public Character PlayerController { get; set; }
        public CharacterStateSetter CharacterStateSetter { get; set; }
        public int Demage { get; set; }
        public float Delay = 0f;
        public float NextStateTime = 0f;

        protected CharacterState(Character controller)
        {
            PlayerController = controller;
            CharacterStateSetter = new CharacterStateSetter(PlayerController);
        }

        public abstract void EnterState();
        public abstract void Update();
    }
}