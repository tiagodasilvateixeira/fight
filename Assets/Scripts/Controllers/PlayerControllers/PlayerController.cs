using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class PlayerController : MonoBehaviour
{
    public string Name { get; set; }
    public int Life { get; set; }
    public int Energy { get; set; }
    public int EspecialPower { get; set; }
    public byte Orientation { get; set; }
    public bool IA { get; set; }
    public bool grounded;
    public int Speed = 5;
    public float JumpForce = 500f;
    public float GroundDistance = 2.2f;
    public float EnemyDistance = 2f;
    public string CharacterName;
    public PlayerState PlayerState;
    public LayerMask GroundLayer;
    public LayerMask EnemyLayer;
    public Image Mask;
    public new Rigidbody2D rigidbody2D;
    public Animator animator;
    public Vector2 input;
    
    public void SetState(PlayerState playerState)
    {
        PlayerState = playerState;
        PlayerState.EnterState();
    }
    public void SetHealth(float value)
    {
        HealthBarController.instance.SetHealthValue(value, Mask);
    }
    public void SetGroundedAnimator()
    {
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
    }
    public void CheckHitReceived()
    {
        //Debug.DrawLine(transform.position, (new Vector3(transform.position.x + EnemyDistance, transform.position.y, 0)), Color.white, 50.5f);
        if (Physics2D.Raycast(transform.position, Vector3.left, EnemyDistance, EnemyLayer))
        {
            Debug.Log($"{this.Name} received demage");
        }
        else if (Physics2D.Raycast(transform.position, Vector3.right, EnemyDistance, EnemyLayer))
        {
            Debug.Log($"{this.Name} received demage");
        }
    }
    public bool WalkInput()
    {
        if (!Mathf.Approximately(input.x, 0.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Idle()
    {
        animator.SetBool("idle", true);
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
        animator.SetTrigger("hit");
    }
    public void KO()
    {
        animator.SetTrigger("ko");
    }
    public void Win()
    {
        animator.SetTrigger("win");
    }
}