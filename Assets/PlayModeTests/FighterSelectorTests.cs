using System.Collections;
using System.Collections.Generic;
using Controllers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]
    public class FighterSelectorTests
    {
        GameObject canvasGameObject;
        FightSelectorCanvasController fighterSelectorCanvasController;

        [SetUp]
        public void Init()
        {
            canvasGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/FightSelectorCanvas"));
            fighterSelectorCanvasController = canvasGameObject.GetComponent<FightSelectorCanvasController>();
        }

        [Test]
        public void InitFightButtonShouldBeDisabledIfAFighterButtonIsNotSelected()
        {
            Assert.AreEqual(false, GameObject.Find("ButtonFight").GetComponent<Button>().interactable);
        }

        [TestCase("Ryu")]
        [TestCase("Blanka")]
        public void InitFightButtonShouldBeEnabledIfAFighterIsSelected(string fighter)
        {
            fighterSelectorCanvasController.SelectFighter(fighter);

            Assert.AreEqual(true, GameObject.Find("ButtonFight").GetComponent<Button>().interactable);
        }
    }
}