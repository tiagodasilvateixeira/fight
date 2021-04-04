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

            Assert.IsTrue(int.Parse(counterText.text.ToString()) >= 0 && int.Parse(counterText.text.ToString()) <= 1);
        }

        [UnityTest]
        public IEnumerator PanelMaskHealthShouldBindPlayerLife()
        {
            Mask healthBarMask = fightPanelGameObject.GetComponentInChildren<Mask>();
            HealthBarController healthBar = fightPanelGameObject.GetComponentInChildren<HealthBarController>();
            float healtValue = 0.8f;
            float expectedMaskSize = healthBarMask.rectTransform.rect.width * healtValue;

            healthBar.SetMaskWidth(healtValue);
            yield return new WaitForFixedUpdate();

            Assert.AreEqual(expectedMaskSize, healthBarMask.rectTransform.rect.width);
        }
    }
}
