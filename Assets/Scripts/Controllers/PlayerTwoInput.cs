using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerTwoInput : CharacterInput
    {
        Vector3 enemyInHitDistance;
        bool goingToEnemy = true;
        float timeSinceLastAtack;
        float timeSinceLastEspecialAtack;
        bool canPunch = false;
        bool canKick = false;
        bool especialAtackEnabled = false;

        private void Awake()
        {
            Enabled = true;
        }

        private void Update()
        {
            if (Enabled)
            {
                enemyInHitDistance = PlayerController.GetEnemyDirection(2f);
                IncraseTimeSinceLastAtack();
                StartCoroutine(WaitForHorizontalInput());
            }
        }

        void IncraseTimeSinceLastAtack()
        {
            if (!canPunch)
            {
                timeSinceLastAtack += Time.deltaTime;
            }
            if (!especialAtackEnabled)
            {
                timeSinceLastEspecialAtack += Time.deltaTime;
            }
            if (timeSinceLastAtack > 2f)
            {
                if (timeSinceLastEspecialAtack > 5)
                {
                    especialAtackEnabled = true;
                }
                else
                {
                    EnableAtack();
                }
                goingToEnemy = true;
            }
        }

        IEnumerator WaitForHorizontalInput()
        {
            yield return new WaitForSeconds(1f);
            input = GetHorizontalInput();
        }

        public override Vector2 GetHorizontalInput()
        {
            if (goingToEnemy && enemyInHitDistance == Vector3.zero)
                return new Vector2(-1.0f, 0.0f);
            
            return new Vector2();
        }

        void EnableAtack()
        {
            if (Time.deltaTime/2 == 0)
            {
                canPunch = true;
            }
            else
            {
                canKick = true;
            }
        }

        public override bool GetJumpCommand()
        {
            return false;
        }

        public override bool GetKickCommand()
        {
            if (canKick && enemyInHitDistance != Vector3.zero)
            {
                timeSinceLastAtack = 0.0f;
                canKick = false;
                goingToEnemy = false;
                return true;
            }
            return false;
        }

        public override bool GetPunchCommand()
        {
            if (canPunch && enemyInHitDistance != Vector3.zero)
            {
                timeSinceLastAtack = 0.0f;
                canPunch = false;
                goingToEnemy = false;
                return true;
            }
            return false;
        }

        public override bool GetBlockCommand()
        {
            return false;
        }

        public override bool GetEspecialAtackCommand()
        {
            if (especialAtackEnabled && enemyInHitDistance != Vector3.zero)
            {
                timeSinceLastAtack = 0.0f;
                timeSinceLastEspecialAtack = 0.0f;
                especialAtackEnabled = false;
                goingToEnemy = false;
                return true;
            }
            return false;
        }
    }
}