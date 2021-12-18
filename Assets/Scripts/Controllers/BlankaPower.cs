using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class BlankaPower : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.name.Contains("Blanka"))
            {
                CallFighters.Instance.CharacterPlayerTwo.especialAtackTriggered = false;
            }
        }
    }
}