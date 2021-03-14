using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FighterSelectorSceneController: MonoSingleton<FighterSelectorSceneController>
{
    private Button InitFight
    {
        get
        {
            return GameObject.Find("ButtonFight").GetComponent<Button>();
        }
        set{}
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("FighterSelectorScene", LoadSceneMode.Single);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "FighterSelectorScene")
            EnableInitFightButtonIfAFighterIsSelected();
    }

    private void EnableInitFightButtonIfAFighterIsSelected()
    {
        if (Card.Player1Fighter != null)
            InitFight.interactable = true;
    }
    
    public void SelectFighter(string fighterName)
    {
        Card.SetPlayer1Fighter(fighterName);
    }
}
