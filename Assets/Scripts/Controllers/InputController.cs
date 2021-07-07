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
                input = GetHorizontalInput();
            }
        }

        public override Vector2 GetHorizontalInput()
        {
            return new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        }

        public override bool GetJumpCommand()
        {
            return Input.GetButtonDown("Jump");
        }

        public override bool GetPunchCommand()
        {
            return Input.GetKeyDown(KeyCode.J);
        }

        public override bool GetKickCommand()
        {
            return Input.GetKeyDown(KeyCode.K);
        }

        public override bool GetBlockCommand()
        {
            return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        }
    }
}