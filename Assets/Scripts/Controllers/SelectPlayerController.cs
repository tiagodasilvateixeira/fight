using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerController: GameController
{
    #region internal proprierts
        public string Music { get; private set; }
        public bool StartFight { get; set; }
        public bool BackToMenu { get; set; }
    #endregion

    #region states
        protected GameState SelectPlayerState;
    #endregion

    private void Start() 
    {
        SelectPlayerState = new SelectPlayerState(this);
        SetState(SelectPlayerState);
    }

    private void Update() 
    {
        GameState.Update();
    }
}
