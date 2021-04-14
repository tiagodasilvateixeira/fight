using Controllers;
using Fight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlankaController : PlayerController
{
    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        
        if (Card.Player1Fighter == Name)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
