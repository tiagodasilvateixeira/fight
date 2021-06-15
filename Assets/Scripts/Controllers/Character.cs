using Controllers;
using States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private string characterName;
        [SerializeField]
        private int characterLife;
        [SerializeField]
        private int characterEnergy;
        [SerializeField]
        private bool characterGrounded = true;
        [SerializeField]
        private float GroundDistance = 2.2f;
        [SerializeField]
        private int Speed = 5;
        [SerializeField]
        private float JumpForce = 500f;
        [SerializeField]
        private byte Orientation;
        [SerializeField]
        private GameObject EnemyGameObject;
        [SerializeField]
        private LayerMask GroundLayer;
        [SerializeField]
        private LayerMask EnemyLayer;
        private CharacterInput CharacterInput;
        public bool IA { get; private set; }
        private PlayerState PlayerState { get; set; }

        public string Name
        {
            get
            {
                return characterName;
            }
        }
        public int Life
        {
            get
            {
                return characterLife;
            }
        }
        public int Energy
        {
            get
            {
                return characterEnergy;
            }
        }
        public bool Grounded
        {
            get
            {
                return characterGrounded;
            }
            private set
            {
                characterGrounded = value;
            }
        }
        private Rigidbody2D CharacterRigidbody2D
        {
            get
            {
                return GetComponent<Rigidbody2D>();
            }
        }
        private Animator CharacterAnimator
        {
            get
            {
                return GetComponent<Animator>();
            }
        }
        

        private void Awake()
        {
            CharacterInput = GetComponent<CharacterInput>();
        }

        private void Start()
        {
            PlayerState = new IdleState(this);
            SetState(PlayerState);
        }

        private void Update()
        {
            SetGroundedAnimator();
            PlayerState.Update();
        }

        public void SetState(PlayerState playerState)
        {
            PlayerState = playerState;
            PlayerState.EnterState();
        }

        public void SetGroundedAnimator()
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, GroundDistance, GroundLayer))
            {
                CharacterAnimator.SetBool("grounded", true);
                Grounded = true;
            }
            else
            {
                CharacterAnimator.SetBool("grounded", false);
                Grounded = false;
            }
        }

        public void SetHealth(int value)
        {
            characterLife = value;
        }

        public bool WalkInput()
        {
            if (!Mathf.Approximately(CharacterInput.input.x, 0.0f))
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
            CharacterAnimator.SetBool("idle", true);
        }

        public void Walk()
        {
            CharacterAnimator.SetBool("idle", false);
            transform.position = CharacterRigidbody2D.position + (CharacterInput.input * Speed * Time.deltaTime);
        }

        public void Jump()
        {
            CharacterAnimator.SetTrigger("jump");
            CharacterRigidbody2D.AddForce(Vector3.up * JumpForce);
        }

        public void Punch()
        {
            CharacterAnimator.SetTrigger("punch");
        }

        public void Kick()
        {
            CharacterAnimator.SetTrigger("kick");
        }

        public void Block()
        {
            CharacterAnimator.SetBool("block", true);
            CharacterAnimator.SetBool("idle", false);
        }

        public void EspecialAtack()
        {
            throw new System.NotImplementedException();
        }

        public void Hit(float force, Vector3 direction)
        {
            CharacterAnimator.SetTrigger("hit");
            CharacterRigidbody2D.AddForce(direction * force);
        }

        public void KO()
        {
            CharacterAnimator.SetTrigger("ko");
            CharacterInput.Enabled = false;
        }

        public void Win()
        {
            CharacterAnimator.SetTrigger("win");
            CharacterInput.Enabled = false;
        }
    }
}