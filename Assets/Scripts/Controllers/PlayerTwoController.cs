using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerTwoController : CharacterInput
    {
        private Vector3 enemyDirectionInDistance;
        bool goingToEnemy = true;
        bool punched = false;
        bool kicked = false;

        private void Awake()
        {
            Enabled = true;
        }

        private void Update()
        {
            if (Enabled)
            {
                enemyDirectionInDistance = PlayerController.GetEnemyDirectionInDistance(2f);
                input = GetHorizontalInput();
            }
        }

        public override Vector2 GetHorizontalInput()
        {
            if (goingToEnemy && enemyDirectionInDistance == Vector3.zero)
                return new Vector2(-1.0f, 0.0f);
            
            goingToEnemy = false;
            return new Vector2();
        }

        public override bool GetJumpCommand()
        {
            return false;
        }

        public override bool GetKickCommand()
        {
            if (punched && enemyDirectionInDistance != Vector3.zero)
                return true;
            punched = false;
            return false;
        }

        public override bool GetPunchCommand()
        {
            if (!punched && enemyDirectionInDistance != Vector3.zero)
                return true;
            punched = true;
            return false;
        }

        public override bool GetBlockCommand()
        {
            return false;
        }
    }
}