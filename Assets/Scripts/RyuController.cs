using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuController : MonoBehaviour
{
    #region public proprierts
        public int Speed = 5;
        public float JumpForce = 500f;
        public float GroundDistance = 2.2f;
        public LayerMask GroundLayer;
    #endregion

    #region internal components and proprierts
        new Rigidbody2D rigidbody2D;
        Animator animator;
        bool grounded;
    #endregion

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
    }

    void Update()
    {
        
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Mathf.Approximately(input.x, 0.0f))
        {
            animator.SetBool("idle", true);
        }
        else
        {
            animator.SetBool("idle", false);
            transform.position = rigidbody2D.position + (input * Speed * Time.deltaTime);
        }

        if (Physics2D.Raycast(transform.position, Vector3.down, GroundDistance, GroundLayer))
        {
            animator.SetBool("grounded", true);
            grounded = true;
        }
        else
        {
            animator.SetBool("grounded", false);
            grounded = false;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetTrigger("jump");
            rigidbody2D.AddForce(Vector3.up * JumpForce);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("punch");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("kick");
        }
    }
}
