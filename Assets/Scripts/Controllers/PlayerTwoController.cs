using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerTwoController : CharacterInput
    {
        Vector3 enemyInHitDistance;
        bool goingToEnemy = true;
        float timeSinceLastAtack;
        bool canPunch = false;
        bool canKick = false;

        private void Awake()
        {
            Enabled = true;
        }

        private void Update()
        {
            if (Enabled)
            {
                enemyInHitDistance = PlayerController.GetEnemyDirectionInDistance(2f);
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
            if (timeSinceLastAtack > 2f)
            {
                canPunch = true;
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

        public override bool GetJumpCommand()
        {
            return false;
        }

        public override bool GetKickCommand()
        {
            if (canKick && enemyInHitDistance != Vector3.zero)
            {
                timeSinceLastAtack = 0.0f;
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
    }
}