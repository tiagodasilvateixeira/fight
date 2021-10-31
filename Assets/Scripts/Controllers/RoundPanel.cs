using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundPanel : MonoBehaviour
{
    [SerializeField]
    private Text CounterText;

    void Start()
    {
        DisableRoundFightImage();
    }

    private void Update()
    {
        if (int.Parse(CounterText.text) > 85)
        {
            EnableRoundFightImage();
        }
        else
        {
            DisableRoundFightImage();
        }
    }

    public void EnableRoundFightImage()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void DisableRoundFightImage()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }
}