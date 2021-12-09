using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class RyuPower : MonoBehaviour
    {
        private void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (new Vector2(1, 0) * 10 * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.name.Contains("Ryu"))
            {
                CallFighters.Instance.CharacterPlayerOne.especialAtackTriggered = false;
                Destroy(gameObject);
            }
        }
    }
}