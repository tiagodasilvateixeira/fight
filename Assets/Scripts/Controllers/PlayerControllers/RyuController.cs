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
        Life = 100;
        Name = CharacterName;
        IA = true;

        PlayerState = new IdleState(this);
        SetState(PlayerState);
    }

    public void Update()
    {
        SetGroundedAnimator();
        PlayerState.Update();
        if (!IA)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        }
    }
}
