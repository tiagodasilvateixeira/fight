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
        private float groundDistance = 2.2f;
        [SerializeField]
        private int speed = 5;
        [SerializeField]
        private float jumpForce = 500f;
        [SerializeField]
        private byte orientation;
        [SerializeField]
        private GameObject EnemyGameObject;
        [SerializeField]
        private LayerMask GroundLayer;
        [SerializeField]
        private int EnemyLayer;
        public CharacterInput CharacterInput { get; set; }
        public bool IA { get; private set; }
        private CharacterState CharacterState { get; set; }

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

        private void Start()
        {
            SetCharacterInput();

            CharacterState = new IdleState(this);
            SetState(CharacterState);
        }

        private void Update()
        {
            SetGroundedAnimator();
            CheckHitReceived();
            CharacterState.Update();
        }

        public void SetCharacterInput()
        {
            CharacterInput = GetComponent<CharacterInput>();
        }

        public void SetState(CharacterState playerState)
        {
            CharacterState = playerState;
            CharacterState.EnterState();
        }

        public void SetGroundedAnimator()
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, groundDistance, GroundLayer))
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

        public void CheckHitReceived()
        {
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector3.left, 3f, EnemyLayer);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector3.right, 3f, EnemyLayer);
            Debug.DrawLine(transform.position, new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z), Color.green);
            int demage = 0;
            if (leftHit || rightHit)
            {
                switch (EnemyGameObject.GetComponent<Character>().CharacterState.GetType().ToString())
                {
                    case "PunchState":
                        CharacterState.CharacterStateSetter.SetHitState(100f, leftHit ? Vector3.right : Vector3.left);
                        demage = 8;

                        SetHealth(Life - demage);
                        break;
                    case "KickState":
                        CharacterState.CharacterStateSetter.SetHitState(300f, leftHit ? Vector3.right : Vector3.left);
                        demage = 10;

                        SetHealth(Life - demage);
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetEnemy(GameObject enemyGameObject)
        {
            EnemyGameObject = enemyGameObject;
            EnemyLayer = enemyGameObject.layer;
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
            CharacterAnimator.SetBool("block", false);
        }

        public void Walk()
        {
            CharacterAnimator.SetBool("idle", false);
            transform.position = CharacterRigidbody2D.position + (CharacterInput.input * speed * Time.deltaTime);
        }

        public void Jump()
        {
            CharacterAnimator.SetTrigger("jump");
            CharacterRigidbody2D.AddForce(Vector3.up * jumpForce);
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