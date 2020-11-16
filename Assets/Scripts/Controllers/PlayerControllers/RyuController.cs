using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RyuController : PlayerController, IPlayer
{
    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
        Life = 100;
        Name = CharacterName;
        IA = false;

        PlayerState = new IdleState(this);
        SetState(PlayerState);
    }

    public void Update()
    {
        PlayerState.Update();
        if (!IA)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        }

        

        if (Input.GetKeyDown(KeyCode.K))
        {
            Kick();
        }
    }
}
