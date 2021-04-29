using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class FighterSelectorSceneController : MonoSingleton<FighterSelectorSceneController>
    {
        public void OpenScene()
        {
            SceneManager.LoadScene("FighterSelectorScene", LoadSceneMode.Single);
        }
    }
}