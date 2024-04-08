using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_MoveManager : OI_InputManager
    {
        [Header("Player Setup")]
        [Space]
        [SerializeField] GameObject player;
        [SerializeField] GameObject playerRender;
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] Animator animator;
        [Space]
        [Header("Movement Setup")]
        [Space]
        [SerializeField] private bool _autoJumpOn;
        [SerializeField] private float _speed;
        [SerializeField] public float _jumpPower;
        [SerializeField] private float _maxVelocity;
        [Space]
        [Header("Jump Setup")]
        [Space]
        [SerializeField] GameObject rayPosLeft;
        [SerializeField] GameObject rayPosCenter;
        [SerializeField] GameObject rayPosRight;
        [SerializeField] private float _jumpRayDist;
        [SerializeField] private LayerMask _layerMask;
        [Space]
        [Header("Movement Setup")]
        [Space]
        [SerializeField] GameObject _boundLeft;
        [SerializeField] GameObject _boundRight;
        
        private bool _canJump;
        private bool _activateAutoJump;
        public int colorIndex {  get; private set; }

        private void Update() {
            if (JumpInput) _activateAutoJump = true;
            RayCheckGround();
            BorderCheck();
            CheckJump();
        }
        private void FixedUpdate() { 
            Move(); 
            SpeedLimit();
        }
        private void RayCheckGround()   {
            RaycastHit2D hitGroundLeft = Physics2D.Raycast(rayPosLeft.transform.position, Vector2.down, _jumpRayDist, _layerMask);
            RaycastHit2D hitGroundCenter = Physics2D.Raycast(rayPosCenter.transform.position, Vector2.down, _jumpRayDist, _layerMask);
            RaycastHit2D hitGroundRight = Physics2D.Raycast(rayPosRight.transform.position, Vector2.down, _jumpRayDist, _layerMask);

            Debug.DrawRay(rayPosLeft.transform.position, Vector2.down * hitGroundLeft.distance, Color.green);
            Debug.DrawRay(rayPosCenter.transform.position, Vector2.down * hitGroundCenter.distance, Color.red);
            Debug.DrawRay(rayPosRight.transform.position, Vector2.down * hitGroundRight.distance, Color.blue);

            if (hitGroundLeft.collider || hitGroundRight.collider || hitGroundCenter.collider) {
                _canJump = true;
                animator.SetBool("InAir", false);
            }
            else {
                _canJump = false;
                animator.SetBool("InAir", true);
            }
        }
        private void BorderCheck() {
            var playerPos = player.transform.position;
            var borderLeft = _boundLeft.transform.position.x;
            var borderRight = _boundRight.transform.position.x;

            if (playerPos.x < borderLeft)
                player.transform.position = new Vector3(borderRight, playerPos.y, 0);
            else if (playerPos.x > borderRight)
                player.transform.position = new Vector3(borderLeft, playerPos.y, 0);
        }
        private void CheckJump() {
            if (_canJump && JumpInput && !_autoJumpOn && (_rb.velocity.y <= 0)) Jump();
            else if (_autoJumpOn && _activateAutoJump && _canJump && (_rb.velocity.y <= 0)) Jump();
        }
        private void Jump()
        {
            colorIndex = Random.Range(0, 10);

            _rb.velocity = new Vector2(_rb.velocity.x,0);
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _canJump = false;
        }
        private void Move() {
            _rb.velocity = new Vector2(MoveInput * _speed, _rb.velocity.y);
            if (MoveInput > 0) playerRender.transform.localScale = new Vector3(-1,1,1);
            else if (MoveInput < 0) playerRender.transform.localScale = new Vector3(1,1,1);
        }
        private void SpeedLimit() => _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxVelocity);
    }
}

