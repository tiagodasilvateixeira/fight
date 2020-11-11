using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RyuController : MonoBehaviour, IPlayer
{
    #region public proprierts
        public int Speed = 5;
        public float JumpForce = 500f;
        public float GroundDistance = 2.2f;
        public string CharacterName = "Ryu";
        public LayerMask GroundLayer;
        public Image Mask;
    #endregion

    #region internal components and proprierts
        new Rigidbody2D rigidbody2D;
        Animator animator;
        Vector2 input;
        bool grounded;
    #endregion

    #region IPlayer proprierts
        public string Name { get; set; }
        public int Life { get; set; }
        public int Energy { get; set; }
        public int EspecialPower { get; set; }
        public byte Orientation { get; set; }
        public bool IA { get; set; }
    #endregion

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
        Life = 100;
        Name = CharacterName;
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

    void SetHealth(float value)
    {
        HealthBarController.instance.SetHealthValue(value, Mask);
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
