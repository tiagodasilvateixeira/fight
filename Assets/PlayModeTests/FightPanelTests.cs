using Controllers;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class FightPanelTests
    {
        GameObject fightPanelGameObject;
        FightPanelController fightPanelController;

        [SetUp]
        public void init()
        {
            fightPanelGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/FightPanel"));
            fightPanelController = fightPanelGameObject.GetComponent<FightPanelController>();
        }

        [UnityTest]
        public IEnumerator CounterTextShouldDecraseByOneEverySecond()
        {
            Text counterText = fightPanelGameObject.GetComponentInChildren<Text>();
            int valueToInitCount = 2;

            fightPanelController.InitCounter(valueToInitCount);
            yield return new WaitForSeconds(1f);

            Assert.Greater(valueToInitCount, int.Parse(counterText.text.ToString()));
        }
    }
}
