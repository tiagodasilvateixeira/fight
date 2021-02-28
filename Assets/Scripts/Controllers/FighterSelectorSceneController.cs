using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FighterSelectorSceneController: MonoSingleton<FighterSelectorSceneController>
{
    public string FighterSelected { get; set; }

    public void OpenScene()
    {
        SceneManager.LoadScene("FighterSelectorScene", LoadSceneMode.Single);
    }
}
