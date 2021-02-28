using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController: MonoSingleton<MenuSceneController>
{
    public void LoadSelectFightersScene()
    {
        SelectPlayerSceneController.Instance.OpenScene();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}