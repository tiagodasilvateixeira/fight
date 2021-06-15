using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class SceneController : MonoSingleton<SceneController>
    {
        [SerializeField]
        private Scene scene;
        [SerializeField]
        private Scene nextScene;

        public Scene Scene
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
        public Scene NextScene
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
            SceneManager.LoadScene(Scene.name, mode);
        }
    }
}