using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _castLength;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private PlatformBase _onPlayerDie;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _castLength, _groundMask);
        Debug.DrawLine(_rigidbody.transform.position, _rigidbody.transform.position + Vector3.down * _castLength, Color.green);

        Run();
        if (_isGrounded)
        {
            Jump();
        }

    }
    void Run()
    {
        Vector3 localScale = transform.localScale;

        var direction = Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);

        if (direction < 0)
        {
            localScale.x = Mathf.Abs(localScale.x) * -1;
            transform.localScale = localScale;
            anim.SetBool("isRun", true);
        }
        else if (direction > 0)
        {
            localScale.x = Mathf.Abs(localScale.x);
            transform.localScale = localScale;
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

    }

    void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", true);
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
        else if (_isGrounded && anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
        }
    }
    private void OnDestroy()
    {
        _onPlayerDie.Execute();
    }
}

