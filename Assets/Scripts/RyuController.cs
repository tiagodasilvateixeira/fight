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
        Vector2 input;
        bool grounded;
    #endregion

    #region IPlayer proprierts
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
        
        input = new Vector2(Input.GetAxis("Horizontal"), 0.0f);

        if (Mathf.Approximately(input.x, 0.0f))
        {
            animator.SetBool("idle", true);
        }
        else
        {
            Walk();
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
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Punch();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Kick();
        }
    }

    public void Walk()
    {
        animator.SetBool("idle", false);
        transform.position = rigidbody2D.position + (input * Speed * Time.deltaTime);
    }
    public void Jump()
    {
        animator.SetTrigger("jump");
        rigidbody2D.AddForce(Vector3.up * JumpForce);
    }
    public void Punch()
    {
        animator.SetTrigger("punch");
    }
    public void Kick()
    {
        animator.SetTrigger("kick");
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
