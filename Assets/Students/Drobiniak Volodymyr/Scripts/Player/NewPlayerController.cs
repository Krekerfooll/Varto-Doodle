using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Students.Drobiniak_Volodymyr.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D),(typeof(BoxCollider2D)), (typeof(SpriteRenderer)))]
    

    public class NewPlayerController : MonoBehaviour
    {
        [Header("HORIZONTAL MOVEMENT")]
        [SerializeField, Range(0, 100)] private float speed = 10f;
        [Space(2)]
    
    
        [Header("JUMP")] 
        [SerializeField, Range(0, 100)] private float jumpPower = 20f;
        [SerializeField] private Transform groundChecker;
        [FormerlySerializedAs("radiusChecker")] [SerializeField] private float distanceChecker;
        [SerializeField] private LayerMask platformGround;
        [FormerlySerializedAs("_playerRb")]
        [Space(2)]
    
        
        [SerializeField] private Rigidbody2D playerRb;
        [SerializeField] private SpriteRenderer playerSr;
        
        private float _direction;
        private bool _isOnTheGround;
        private bool _canJump;
        [SerializeField] private int _gemCounter = 0;
        
    
    
        void Awake() 
        {
            if(playerRb == null)playerRb = GetComponent<Rigidbody2D>();
            if(playerRb == null)playerSr = GetComponent<SpriteRenderer>(); 
        }

        void Update()
        { 
            _direction = Input.GetAxis("Horizontal");
            CheckIsOnTheGround();
            _canJump = Input.GetButtonDown("Jump");
            Flip(_direction);
            PlayerMovement(_direction);
            PlayerJump();
        }

        void PlayerMovement(float direction)
        {     
            transform.Translate(Vector2.right * (direction * speed * Time.deltaTime));
        }

        void Flip(float direction)
        {
            if (direction < 0 )
            {
                playerSr.flipX = true; // Фліп спрайту, якщо horizontal < 0 (рухаємося вліво)
            }
            else if (direction > 0 )
            {
                playerSr.flipX = false; // Протилежний фліп, якщо horizontal > 0 (рухаємося вправо)
            }
        }
        
        /// <summary>
        /// Перевіряє, чи існує контакт між гравцем і землею, використовуючи коло з центром у позиції groundChecker.position, радіусом radiusChecker, і перевіряючи колайдери на шарі platformGround.
        /// </summary>
        void CheckIsOnTheGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(groundChecker.position, Vector2.down, distanceChecker, platformGround);
            _isOnTheGround = hit.collider != null; // Перевіряємо, чи є зіткнення з колайдером
            Debug.DrawLine(groundChecker.position, groundChecker.position + (Vector3.down * distanceChecker), Color.black);
        }

        void PlayerJump()
        {
            if (_canJump && _isOnTheGround)
            {
                playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Gem"))
            {
                Debug.Log(gameObject.name+" contact with " + other.gameObject.name);
                _gemCounter += 1;
                Destroy(other.gameObject);
            }
        }

        private void FixedUpdate()
        {
            // PlayerMovement(_direction);
            // PlayerJump();
        }
    }
}