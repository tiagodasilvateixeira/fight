using UnityEngine;

namespace Controllers
{
    public abstract class CharacterInput: MonoBehaviour
    {
        public Character PlayerController { get; set; }
        public bool Enabled { get; set; }
        public Vector2 input { get; set; }

        public abstract Vector2 GetHorizontalInput();
        public abstract bool GetJumpCommand();
        public abstract bool GetPunchCommand();
        public abstract bool GetKickCommand();
        public abstract bool GetBlockCommand();
        public abstract bool GetEspecialAtackCommand();
    }
}