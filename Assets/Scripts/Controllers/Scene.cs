using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class Scene : MonoSingleton<Scene>
    {
        [SerializeField]
        private string scene;
        [SerializeField]
        private string nextScene;

        public string ActualScene
        {
            get
            {
                return scene;
            }
            private set
            {
                scene = value;
            }
        }
        public string NextScene
        {
            get
            {
                return nextScene;
            }
            set
            {
                nextScene = value;
            }
        }

        public void LoadNextScene(LoadSceneMode mode)
        {
            SceneManager.LoadScene(NextScene, mode);
        }
    }
}