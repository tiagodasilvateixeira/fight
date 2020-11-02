using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightController: GameController
{

    #region internal proprierts
        public string Music { get; private set; }
        public bool PauseMenu { get; set; }
    #endregion

    #region states
        protected GameState FightState;
    #endregion

    private void Start() 
    {
        FightState = new FightState(this);
        SetState(FightState);
    }

    private void Update() 
    {
        GameState.Update();
    }
}
