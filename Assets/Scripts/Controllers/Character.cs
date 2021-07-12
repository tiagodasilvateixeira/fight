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
        private LayerMask EnemyLayer;
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
            CharacterInput.PlayerController = this;
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

        void CheckHitReceived()
        {
            Vector3 enemyDirectionInDistance = GetEnemyDirectionInDistance(2f);
            HitMeIfEnemyDemageIsGreaterThan0(EnemyGameObject.GetComponent<Character>().CharacterState.Demage, enemyDirectionInDistance);
        }

        public Vector3 GetEnemyDirectionInDistance(float distance)
        {
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector3.left, distance, EnemyLayer);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector3.right, distance, EnemyLayer);
            if (leftHit)
                return Vector3.left;
            else if (rightHit)
                return Vector3.right;
            return new Vector3();
        }

        void HitMeIfEnemyDemageIsGreaterThan0 (int force, Vector3 enemyDirection)
        {
            if (force > 0)
            {
                SetHealth(Life - EnemyGameObject.GetComponent<Character>().CharacterState.Demage);
                CharacterState.CharacterStateSetter.SetHitState(100f, enemyDirection == Vector3.left ? Vector3.right : Vector3.left);
            }
        }

        public void SetEnemy(GameObject enemyGameObject, string layerMask)
        {
            EnemyGameObject = enemyGameObject;
            EnemyLayer = LayerMask.GetMask(layerMask);
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