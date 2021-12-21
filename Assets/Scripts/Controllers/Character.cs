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
        private AudioSource punchAudio;
        [SerializeField]
        private AudioSource especialAudio;
        [SerializeField]
        private GameObject enemyGameObject;
        [SerializeField]
        private GameObject especialAtackItem;
        public bool especialAtackTriggered;
        [SerializeField]
        private GameObject especialAtackItemSpawnLocation;
        [SerializeField]
        private LayerMask groundLayer;
        [SerializeField]
        private LayerMask enemyLayer;
        private Vector3 enemyDirection;
        private CharacterState CharacterState { get; set; }
        public CharacterInput CharacterInput { get; set; }
        public Mask HealthMask { get; set; }
        public bool IA { get; private set; }

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
        private HealthBar HealthMaskController
        {
            get
            {
                return HealthMask.GetComponentInChildren<HealthBar>();
            }
        }

        private void Start()
        {
            SetCharacterInput();
            SetEnemyDirection();

            CharacterState = new IdleState(this);
            SetState(CharacterState);
        }

        private void Update()
        {
            SetGroundedAnimator();
            SetOrientation();
            CharacterState.Update();
        }

        public void SetCharacterInput()
        {
            CharacterInput = GetComponent<CharacterInput>();
            CharacterInput.PlayerController = this;
        }

        private void SetEnemyDirection()
        {
            enemyDirection = GetEnemyDirection(27);
        }

        public void SetState(CharacterState playerState)
        {
            CharacterState = playerState;
            CharacterState.EnterState();
        }

        public void SetGroundedAnimator()
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, groundDistance, groundLayer))
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

        void SetOrientation()
        {
            if (enemyDirection == Vector3.left)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            int force = enemyGameObject.GetComponent<Character>().CharacterState.Demage;
            if (collision.gameObject.layer == enemyGameObject.layer)
            {
                Vector3 enemyDirectionInDistance = GetEnemyDirection(2f);
                HitMeIfEnemyDemageIsGreaterThan0(force, enemyDirectionInDistance);
            }
        }

        public Vector3 GetEnemyDirection(float distance)
        {
            RaycastHit2D left = Physics2D.Raycast(transform.position, Vector3.left, distance, enemyLayer);
            RaycastHit2D right = Physics2D.Raycast(transform.position, Vector3.right, distance, enemyLayer);
            if (left)
                return Vector3.left;
            else if (right)
                return Vector3.right;
            return new Vector3();
        }

        public void HitMeIfEnemyDemageIsGreaterThan0(int force, Vector3 enemyDirection)
        {
            if (force > 0)
            {
                SetHealth(Life - enemyGameObject.GetComponent<Character>().CharacterState.Demage);
                CharacterState.CharacterStateSetter.SetHitState(100f, enemyDirection == Vector3.left ? Vector3.right : Vector3.left);
            }
        }

        public void SetEnemy(GameObject enemyGameObject, string layerMask)
        {
            this.enemyGameObject = enemyGameObject;
            enemyLayer = LayerMask.GetMask(layerMask);
        }

        public void SetHealth(int value)
        {
            characterLife = value;
            HealthMaskController.SetMaskWidth((float)characterLife);
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
            CharacterAnimator.SetTrigger("especial");
            especialAudio.Play();
        }

        public void EnableEspecialAtackItem()
        {
            Instantiate(especialAtackItem, especialAtackItemSpawnLocation.transform);
        }

        public void Hit(float force, Vector3 direction)
        {
            CharacterAnimator.SetTrigger("hit");
            punchAudio.Play();
            CharacterRigidbody2D.AddForce(direction * force);
        }

        public void KO()
        {
            CharacterAnimator.SetTrigger("ko");
        }

        public void Win()
        {
            CharacterAnimator.SetTrigger("win");
        }
    }
}