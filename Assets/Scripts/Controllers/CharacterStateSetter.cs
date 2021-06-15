using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CharacterStateSetter : MonoBehaviour
    {
        public Character PlayerController { get; set; }
        protected CharacterStateSetter(Character controller)
        {
        }
    }
}