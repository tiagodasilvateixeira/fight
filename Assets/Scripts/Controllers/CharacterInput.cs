using UnityEngine;

namespace Controllers
{
    public abstract class CharacterInput: MonoBehaviour
    {
        public bool Enabled { get; set; }
        public Vector2 input { get; set; }
    }
}