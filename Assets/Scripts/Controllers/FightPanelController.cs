using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class FightPanelController : MonoSingleton<FightPanelController>
    {
        private readonly int defultCounterValue = 90;
        private int Counter;

        public void InitCounter(int valueToCount)
        {
            Counter = valueToCount;
        }

        public void Start()
        {
            InitCounter(defultCounterValue);
        }

        public void Update()
        {
            StartCoroutine(DecreaseCounterByOneEverySecond());
            StartCoroutine(DisplayCounterValueInPanelText());
        }

        IEnumerator DecreaseCounterByOneEverySecond()
        {
            Counter = Counter - 1;
            yield return new WaitForSeconds(1f);
        }

        IEnumerator DisplayCounterValueInPanelText()
        {
            gameObject.GetComponentInChildren<Text>().text = Counter.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
