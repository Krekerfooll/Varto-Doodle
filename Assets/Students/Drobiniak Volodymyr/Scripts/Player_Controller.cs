using UnityEngine;

namespace Students.Drobiniak_Volodymyr.Scripts
{
    internal class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] int distance = 5;
        [SerializeField, Range (100, 1000)] float jumpPower = 100f;
        [SerializeField] Rigidbody2D playerRb;
        [SerializeField] SpriteRenderer playerSr;
        private bool _isOnGround = true;
    

        void Awake() 
        {
            playerRb = GetComponent<Rigidbody2D>();
            playerSr = GetComponentInChildren<SpriteRenderer>(); 
        }

        void Update()
        {
            PlayerMovement();
            if(Input.GetKeyDown(KeyCode.Space) && _isOnGround) PlayerJump();
        }
    
        void PlayerMovement()
        {        
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal < 0)
            {
                playerSr.flipX = true; // Фліп, якщо horizontal < 0 (рухаємося вліво)
            }
            else if (horizontal > 0)
            {
                playerSr.flipX = false; // Не фліп, якщо horizontal > 0 (рухаємося вправо)
            }
          
            transform.Translate(Vector2.right * horizontal * distance * Time.deltaTime);
        }
    
        void PlayerJump()
        {
            playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);        
            _isOnGround = false;
        }
      
        
        void OnCollisionEnter2D(Collision2D collision) 
        {
            _isOnGround = true;
            Debug.Log(collision.gameObject.name);
        }       
    }
}
