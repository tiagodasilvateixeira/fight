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
            StartCoroutine(DecreaseCounterByOneEverySecond());
        }

        public void Start()
        {
            InitCounter(defultCounterValue);
        }

        IEnumerator DecreaseCounterByOneEverySecond()
        {
            while (Counter > 0)
            {
                Counter--;

                yield return new WaitForSecondsRealtime(1);
                
                gameObject.GetComponentInChildren<Text>().text = Counter.ToString();
            }
        }
    }
}
