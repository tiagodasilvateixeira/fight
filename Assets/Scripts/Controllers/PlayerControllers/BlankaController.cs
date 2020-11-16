using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlankaController : MonoBehaviour, IPlayer
{
    #region public proprierts
        public int Speed = 5;
        public float JumpForce = 500f;
        public float GroundDistance = 2.2f;
        public string CharacterName = "Blanka";
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
        Life = 100;
        Name = CharacterName;
        IA = true;
    }

    public void Update()
    {
        
    }
    void SetHealth(float value)
    {
        HealthBarController.instance.SetHealthValue(value, Mask);
    }
    public bool WalkInput()
    {
        return true;
    }
    public void Idle()
    {
        
    }
    public void Walk()
    {
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
