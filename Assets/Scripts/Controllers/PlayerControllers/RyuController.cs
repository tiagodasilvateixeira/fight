using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RyuController : PlayerController
{
    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
        Life = 1f;
        Name = CharacterName;

        SetEnemyObject();
        PlayerState = new IdleState(this);
        SetState(PlayerState);
    }

    public void Update()
    {
        SetGroundedAnimator();
        
        if (Life >= 0 && winner != true)
        {
            CheckHitReceived();
            PlayerState.Update();
        }

        if (FighterSelectorSceneController.Instance.FighterSelected == Name)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
