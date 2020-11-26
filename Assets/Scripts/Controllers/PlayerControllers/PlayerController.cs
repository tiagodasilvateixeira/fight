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
    public GameObject EnemyGameObject;
    PlayerController Enemy;
    public PlayerState PlayerState;
    public LayerMask GroundLayer;
    public LayerMask EnemyLayer;
    public Image Mask;
    public new Rigidbody2D rigidbody2D;
    public Animator animator;
    public Vector2 input;
    
    public void SetEnemyObject()
    {
        Enemy = EnemyGameObject.GetComponent<PlayerController>();
    }
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
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector3.left, EnemyDistance, EnemyLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector3.right, EnemyDistance, EnemyLayer);
        if (leftHit || rightHit)
        {
            switch (Enemy.PlayerState.GetType().ToString())
            {
                case "PunchState":
                    PlayerState.SetHitState(100f, leftHit == true ? Vector3.right : Vector3.left);
                    break;
                case "KickState":
                    PlayerState.SetHitState(300f, leftHit == true ? Vector3.right : Vector3.left);
                    break;
                default:
                    break;
            }
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
    public void Hit(float value, Vector3 direction)
    {
        animator.SetTrigger("hit");
        rigidbody2D.AddForce(direction * value);
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