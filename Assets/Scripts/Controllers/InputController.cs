using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class InputController : CharacterInput
    {
        private void Awake()
        {
            Enabled = true;
        }

        private void Update()
        {
            if (Enabled)
            {
                input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
            }
        }
    }
}