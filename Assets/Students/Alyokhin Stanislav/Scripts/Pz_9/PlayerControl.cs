using Stanislav.Alokhin.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace Alokhin.Stanislav
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb2;
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        [Space]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private ActionBase _onPlayerDie;
        [SerializeField] private ParticleSystem _dust;

        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private Animator anim;

        //private bool _isJump;
        private bool _isGrounded;

        private void Start()
        {
            anim = GetComponent<Animator>();
            _lookLeft = _rb2.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }
        private void Update()
        {
            CalculateJump();
            CalculateSpeed();

        }

        void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_rb2.position, Vector2.down, _groundCheckDistance, _groundMask);
            Debug.DrawLine(_rb2.position,_rb2.position + Vector2.down * _groundCheckDistance, Color.yellow);

        }

        private void CalculateJump()
        {
            if(_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("takeOf");
                _rb2.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                //_isJump = true;
                CreateDust();
            }
            if ( _isGrounded)
            {
                anim.SetBool("isJumping", false);
                //anim.SetBool("isJumpimg", false);
            }
            else
            {
                anim.SetBool("isJumping", true);
                //anim.SetBool("isJumpimg",true);
            }

        }
        private void CalculateSpeed()
        {
            var _moveDiraction = Input.GetAxis("Horizontal");
            _rb2.velocity = new Vector2(_speed * _moveDiraction, _rb2.velocity.y);
            if(_moveDiraction == 0)
            {
                anim.SetBool("isRunning",false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }

            if (_moveDiraction < 0f)
            {
                _rb2.transform.localScale = _lookLeft;
            }
            else if (_moveDiraction > 0f)
            {
                _rb2.transform.localScale = _lookRight;
            }

        }

        private void CreateDust()
        {
            _dust.Play();
        }

        private void OnDestroy()
        {
            _onPlayerDie.Execute();
        }
    }


}
