using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class FightPanelController : MonoBehaviour
    {
        private readonly int defultCounterValue = 90;
        private int Counter;
        public Toggle TogglePlayer1 { get; private set; }
        public Toggle TogglePlayer2 { get; private set; }

        public void Start()
        {
            SetTogglesComponents();
            InitCounter(defultCounterValue);
        }

        public void InitCounter(int valueToCount)
        {
            Counter = valueToCount;
            StartCoroutine(DecraseCounterByOneEverySecond());
        }

        IEnumerator DecraseCounterByOneEverySecond()
        {
            while (Counter > 0)
            {
                Counter--;
                gameObject.GetComponentInChildren<Text>().text = Counter.ToString();
                yield return new WaitForSecondsRealtime(1);
            }
        }

        void SetTogglesComponents()
        {
            TogglePlayer1 = GameObject.Find("TogglePlayer1").GetComponent<Toggle>();
            TogglePlayer2 = GameObject.Find("TogglePlayer2").GetComponent<Toggle>();
        }

        public void MarkToggle(Toggle toggle)
        {
            toggle.isOn = true;
        }
    }
}