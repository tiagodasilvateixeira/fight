using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]
    public class FighterSelectorTests
    {
        Button ryuButton;
        Button blankaButton;
        Button initFightButton;
        GameObject gameObject;
        FighterSelectorSceneController fighterSelectorSceneController;

        [SetUp]
        public void Init()
        {
            gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/FightSelectorCanvas"));
            fighterSelectorSceneController = gameObject.GetComponent<FighterSelectorSceneController>();
        }

        [Test]
        public void InitFightButtonShouldBeDisabledIfAFighterButtonIsNotSelected()
        {
            GetButtons();

            Assert.AreEqual(false, initFightButton.interactable);
        }

        [Test]
        public void InitFightButtonShouldBeEnabledIfAFighterIsSelected()
        {
            GetButtons();

            ryuButton.interactable = true;
            fighterSelectorSceneController.EnableInitFightButtonIfAFighterIsSelected();

            Assert.AreEqual(true, initFightButton.interactable);
        }

        private void GetButtons()
        {
            Button[] buttons =  Object.FindObjectsOfType<Button>();
            foreach (Button button in buttons)
            {
                if (button.name == "ButtonRyu")
                    ryuButton = button;
                if (button.name == "ButtonBlanka")
                    blankaButton = button;
                if (button.name == "ButtonFight")
                    initFightButton = button;
            }
        }
    }
}