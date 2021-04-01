using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class MenuSceneController : MonoSingleton<MenuSceneController>
    {
        public void OpenScene()
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}