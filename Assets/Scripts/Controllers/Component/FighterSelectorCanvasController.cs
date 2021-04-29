using Fight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class FighterSelectorCanvasController : MonoSingleton<FighterSelectorCanvasController>
    {
        private Button InitFightButton
        {
            get
            {
                return GameObject.Find("ButtonFight").GetComponent<Button>();
            }
        }
        public void SelectFighter(string fighterName)
        {
            Card.SetPlayer1Fighter(fighterName);
            EnableInitFightButton();
        }

        private void EnableInitFightButton()
        {
            InitFightButton.interactable = true;
        }
    }
}