using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuController : MonoBehaviour, IPlayer
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

    #region IPlayer Proprierts
        public short Life { get; set; }
        public short Energy { get; set; }
        public short EspecialPower { get; set; }
        public byte Orientation { get; set; }
        public bool IA { get; set; }
    #endregion

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
    }

    public void Update()
    {
        
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);

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

    public void Walk()
    {

    }
    public void Jump()
    {

    }
    public void Punch()
    {

    }
    public void Kick()
    {

    }
    public void Block()
    {

    }
    public void EspecialAtack()
    {

    }
    public void Hit()
    {

    }
    public void KO()
    {

    }
    public void Win()
    {

    }
}
