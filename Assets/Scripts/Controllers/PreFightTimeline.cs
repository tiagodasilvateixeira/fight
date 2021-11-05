using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Controllers
{
    public class PreFightTimeline : MonoBehaviour, INotificationReceiver
    {
        private void Start()
        {
            Scene.Instance.NextScene = "FightScene";
        }

        public void LoadFightScene()
        {
            Scene.Instance.LoadNextScene(UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        public void OnNotify(Playable origin, INotification notification, object context)
        {
            LoadFightScene();
        }
    }
}