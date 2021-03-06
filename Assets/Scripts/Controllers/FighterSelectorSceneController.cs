using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FighterSelectorSceneController: MonoSingleton<FighterSelectorSceneController>
{
    public string FighterSelected { get; set; }
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
        EnableInitFightButtonIfAFighterIsSelected();
    }

    private void EnableInitFightButtonIfAFighterIsSelected()
    {
        if (FighterSelected != null)
            InitFight.interactable = true;
    }
    
    public void SetSelectedFighter(string fighterName)
    {
        FighterSelected = fighterName;
    }
}
