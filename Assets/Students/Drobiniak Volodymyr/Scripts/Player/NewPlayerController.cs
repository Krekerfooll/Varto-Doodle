using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Students.Drobiniak_Volodymyr.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]

    public class NewPlayerController : MonoBehaviour
    {
        [Header("HORIZONTAL MOVEMENT")]
        [SerializeField, Range(0, 100)] private float speed = 10f;
        [Space(2)]
    
    
        [Header("JUMP")] 
        [SerializeField, Range(0, 100)] private float jumpPower = 20f;
        [SerializeField] private Transform groundChecker;
        [SerializeField] private float radiusChecker;
        [SerializeField] private LayerMask platformGround;
        [FormerlySerializedAs("_playerRb")]
        [Space(2)]
    
        
        [SerializeField] private Rigidbody2D playerRb;
        [SerializeField] private SpriteRenderer playerSr;

        [Header("Temporary")]
        private float _direction;
        [SerializeField] private bool isOnTheGround;
        [SerializeField] private bool canJump;
        
    
    
        void Awake() 
        {
            if(playerRb == null)playerRb = GetComponent<Rigidbody2D>();
            if(playerRb == null)playerSr = GetComponent<SpriteRenderer>(); 
        }

        void Update()
        { 
            _direction = Input.GetAxis("Horizontal");
            CheckIsOnTheGround();
            canJump = Input.GetButtonDown("Jump");
            Flip(_direction);
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
            RaycastHit2D hit = Physics2D.Raycast(groundChecker.position, Vector2.down, radiusChecker, platformGround);
            isOnTheGround = hit.collider != null; // Перевіряємо, чи є зіткнення з колайдером
            Debug.DrawLine(groundChecker.position, groundChecker.position + (Vector3.down * radiusChecker), Color.black);
        }

        void PlayerJump()
        {
            if (canJump && isOnTheGround)
            {
                playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {
            PlayerMovement(_direction);
            PlayerJump();
        }
    }
}